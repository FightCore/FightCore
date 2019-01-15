import { PostService } from 'src/app/services/post.service';
import { Character } from './../../models/Character';
import { Post } from './../../models/Post';
import { DialogData } from './../confirm-dialog/dialog-data.interface';
import { ConfirmDialogComponent } from './../confirm-dialog/confirm-dialog.component';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material';
import { PostInfo } from 'src/app/resources/post-info';
import { EditorComponent } from '../editor/editor.component';

// Validates urls
export function urlValidator(): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} | null => {
    // No value is technically valid
    if (!control.value) {
      return null;
    }

    // Simply try to create a url object and let that handle any complexity
    try {
      new URL(control.value);
      return null;
    } catch (error) {
      return { 'badUrl': true };
    }
  };
}

@Component({
  selector: 'post-editor',
  templateUrl: './post-editor.component.html',
  styleUrls: ['./post-editor.component.css']
})
export class PostEditorComponent implements OnInit {
  // TODO: Input to give feedback if submit fails or otherwise show failed messages
  @Output('onSubmit') onSubmitHandler: EventEmitter<Post> = new EventEmitter();

  @ViewChild('stepper') stepperComponent;
  @ViewChild('bodyEditor') bodyEditor: EditorComponent;

  metaFormGroup: FormGroup;
  contentFormGroup: FormGroup;
  additionalFormGroup: FormGroup;
  resetDialogRef: MatDialogRef<ConfirmDialogComponent>;

  // Whether to show or hide the link preview component (which isn't perfect, component can be changed in the future)
  showLinkPreview = false;
  showYTEmbed = false;

  showGameSpecificFields = false; // Default false as must select a category first
  showCombosFields = false;

  isSubmitting = false;  // Show loading bar on Submit page
  onSubmitErrorMessage = '';

  // Fields for character select
  charSelectTitle: string;        // Title filled in once category is selected
  isCharacterRequired = false;    // Controls asterisk next to character name
  mainCharSelect: number[];
  targetCharSelect: number[];
  // TODO: Allow an 'All' option for Target Character(s)

  postCatgories = PostInfo.PostCategories;
  selectedPostCat: number;

  comboTypesS4 = [
    {
      id: '1',
      name: 'Juggle'
    },
    {
      id: '2',
      name: 'Edgeguard'
    },
    {
      id: '3',
      name: 'Ledgeguard'
    },
    {
      id: '4',
      name: 'Trap'
    },
    {
      id: '5',
      name: 'True Combo'
    },
    {
      id: '6',
      name: 'Kill'
    },
    {
      id: '7',
      name: '0-to-Death'
    }
  ];
  selectedComboType: number[];

  skillCategories = PostInfo.PostSkillCategories;
  selectedSkill: 1; // Initialize to N/A

  patches = [
    {
      id: 0,
      name: 'None (Patch Independent)'
    },
    {
      id: 1,
      name: 'Latest (1.1.7)'
    },
    {
      id: 2,
      name: '1.1.6'
    },
    {
      id: 3,
      name: '1.1.5'
    }
  ];
  selectedPatch: 1; // Initialize to latest patch // TODO: Figure out why not initializing to this

  // TODO: Handle certain special move variations, like KO punch vs normal neutral b?
  moves = [
    {
      id: '1',
      name: 'Jab'
    },
    {
      id: '2',
      name: 'Dash Attack'
    },
    {
      id: '3',
      name: 'Ftilt'
    },
    {
      id: '4',
      name: 'Utilt'
    }
  ];
  selectedComboStarter: number;

  constructor(private formBuilder: FormBuilder, public dialog: MatDialog) { }

  ngOnInit() {
    // TODO: All validators
    this.metaFormGroup = this.formBuilder.group({
      postCatCtrl: [''],
      comboPercCtrl: [''],
      comboTypeCtrl: [''],
      comboDmgCtrl: [''],
      comboStarterCtrl: ['']
    });
    this.contentFormGroup = this.formBuilder.group({
      titleCtrl: ['', Validators.required],
      linkCtrl: ['', urlValidator()]
    });
    this.additionalFormGroup = this.formBuilder.group({
      patchCtrl: ['']
    });
  }

  
  /**
   * Handles when post category selection is changed
   * Determines whether to show or hide additional fields
   */
  onPostCatSelection() {
    // If doing a game-independent post, hide all game-specific controls
    // TODO: Figure out why can't use ===, where's the type difference coming from and how to avoid ==?
    if (this.selectedPostCat === PostInfo.GameIndependentId) {
      this.showGameSpecificFields = false;
      this.showCombosFields = false; // Technically unnecessary but more complete & robust
    } else {
      this.showGameSpecificFields = true;

      // Show combos fields only for combo posts
      if(this.selectedPostCat === PostInfo.CombosCatId) {
        this.showCombosFields = true;

        // Set up main character select as required
        this.charSelectTitle = 'Performed By Character(s)';
        this.isCharacterRequired = true;
      } else {
        this.showCombosFields = false;

        // Character select is optional
        this.charSelectTitle = 'Any relevant character(s)?';
        this.isCharacterRequired = false;
      }
    }
  }

  /**
   * TODO: Handle multiple character selection
   * @param character Selected character
   */
  onMainCharSelect(characters: Character[]) {
    this.mainCharSelect = [];
    characters.forEach(char => this.mainCharSelect.push(char.id));
  }

  /**
   * TODO: Handle multiple character selection
   * @param character Selected character
   */
  onTargetCharSelect(characters: Character[]) {
    this.targetCharSelect = [];
    characters.forEach(char => this.targetCharSelect.push(char.id));
  }

  onFeaturedLinkChange() {
    // If url doesn't match pattern or is blank, nothing to do
    if (this.contentFormGroup.controls.linkCtrl.invalid || !this.contentFormGroup.controls.linkCtrl.value) {
      this.showLinkPreview = false;
      this.showYTEmbed = false;
      return;
    }

    let url: URL;
    try {
      url = new URL(this.contentFormGroup.controls.linkCtrl.value);
    } catch (error) {
      // This area realistically shouldn't ever be hit due to validator BUT just in case
      console.log('Error: Link is valid but does not work as a URL object')
      this.showLinkPreview = false;
      this.showYTEmbed = false;
      return;
    }

    let ytVidId = this.getYoutubeVideoId(this.contentFormGroup.controls.linkCtrl.value);
    // TODO If url matches supported video type, show video icon and preview embed
    if (ytVidId) {
      console.log('Got youtube id!', ytVidId);
      this.showLinkPreview = false; // Hide other preview
      this.showYTEmbed = true;
    } else {
      // Otherwise, show a link preview

      // Show that loading preview
      this.showLinkPreview = true;
      this.showYTEmbed = false;
    }
  }

  /**
   * Opens a dialog to confirm reset, and if confirmed, resets all fields
   */
  onResetClick() {
    let dialogData: DialogData = {
      title: 'Reset Post?',
      body: 'Are you sure you want to reset your post?',
      positiveActionName: 'Reset',
      negativeActionName: 'Cancel'
    };


    // Open the dialog to confirm or deny the reset
    this.resetDialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: dialogData
    })

    // Handle the user's response
    this.resetDialogRef
      .afterClosed()
      .subscribe(isAffirmative => {
        if (isAffirmative) {
          this.stepperComponent.reset();
        }
      });
  }

  /**
   * Handles form validation and outputs post data if seems valid
   */
  onSubmitClick() {
    if (this.isSubmitting) {
      return;
    }

    // TODO: Actually do full validation on all form data first before continuing here
    if(!this.isContentFormValid()) {
      this.onSubmitErrorMessage = 'Form is invalid';
      return;
    }

    this.isSubmitting = true;
    this.onSubmitErrorMessage = '';

    // Populate the post to create with necessary fields
    let post = PostService.getBasicPost();
    post.category = this.selectedPostCat;

    post.title = this.contentFormGroup.controls.titleCtrl.value;
    post.featuredLink = this.contentFormGroup.controls.linkCtrl.value;
    post.content = this.bodyEditor.getContents();

    post.skillLevel = this.selectedSkill;
    post.patchId = this.selectedPatch;

    // If showing other game fields, use their data as well
    if (this.showGameSpecificFields) {
      post.characterIds = this.mainCharSelect;

      if (this.showCombosFields) {
        post.targetCharacterIds = this.targetCharSelect;
        post.comboTypeIds = this.selectedComboType;
        post.targetPercent = this.metaFormGroup.controls.comboPercCtrl.value;
        post.comboDmg = this.metaFormGroup.controls.comboDmgCtrl.value;
        post.comboStarterId = this.selectedComboStarter;
      }
    }

    this.onSubmitHandler.emit(post);
  }

  /**
   * Updates UI after a submission is done
   * @param errorMsg Error message, if any, on this submit attempt
   */
  public onPostSubmit(errorMsg: string) {
    this.isSubmitting = false;
    this.onSubmitErrorMessage = errorMsg;
  }

  /**
   * Determines if the content-specific form group is valid
   * @returns true if content form valid, false if invalid
   */
  private isContentFormValid(): boolean {
    // Basic validators check
    if (this.contentFormGroup.invalid) {
      return false;
    }

    // Post must contain either a video or text at least
    let controls = this.contentFormGroup.controls; // Shortcut
    if (this.bodyEditor.isEmpty() && controls.linkCtrl.value === '') {
      return false;
    }

    // Otherwise, this form is valid
    return true;
  }

  private getYoutubeVideoId(url: string): string {
    // From comment in https://stackoverflow.com/a/8260383/3735890
    let regExp = /.*(?:youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/
    let match = url.match(regExp);
    return (match && match[1]) ? match[1] : '';
  }

  private isSupportedVideo(url: string): string {
    // If youtube vid, return YOUTUBE
    // If 

    return '';
  }
}