import { Character } from './../../models/Character';
import { Post } from './../../models/Post';
import { DialogData } from './../confirm-dialog/dialog-data.interface';
import { ConfirmDialogComponent } from './../confirm-dialog/confirm-dialog.component';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material';

@Component({
  selector: 'post-editor',
  templateUrl: './post-editor.component.html',
  styleUrls: ['./post-editor.component.css']
})
export class PostEditorComponent implements OnInit {
  // TODO: Input to give feedback if submit fails or otherwise show failed messages
  @Output('onSubmit') onSubmitHandler: EventEmitter<Post> = new EventEmitter();

  @ViewChild('stepper') stepperComponent; 
  
  metaFormGroup: FormGroup;
  contentFormGroup: FormGroup;
  additionalFormGroup: FormGroup;
  resetDialogRef: MatDialogRef<ConfirmDialogComponent>;

  static readonly GameIndependentId = 5;
  static readonly CombosCatId = 2;
  
  showGameSpecificFields = false; // Default false as must select a category first
  showCombosFields = false;       

  // Fields for character select
  charSelectTitle: string;        // Title filled in once category is selected
  isCharacterRequired = false;    // Controls asterisk next to character name
  mainCharSelect: number;
  targetCharSelect: number;
  // TODO: Allow multiple character select
  // TODO: Allow an "All" option for Target Character(s)

  postCatgories = [
    {
      id: "1",
      name: "General"
    },
    {
      id: "2",
      name: "Combos"
    },
    {
      id: "3",
      name: "Tech & Mechanics"
    },
    {
      id: "4",
      name: "Community"
    },
    {
      id: "5",
      name: "Game Independent"
    },
  ];
  selectedPostCat: number;

  comboTypesS4 = [
    {
      id: "1",
      name: "Juggle"
    },
    {
      id: "2",
      name: "Edgeguard"
    },
    {
      id: "3",
      name: "Ledgeguard"
    },
    {
      id: "4",
      name: "Trap"
    },
    {
      id: "5",
      name: "True Combo"
    },
    {
      id: "6",
      name: "Kill"
    },
    {
      id: "7",
      name: "0-to-Death"
    }
  ];
  selectedComboType: number[];

  skillCategories = [
    {
      id: 1,
      name: "N/A"
    },
    {
      id: 2,
      name: "Beginner"
    },
    {
      id: 3,
      name: "Intermediate"
    },
    {
      id: 2,
      name: "Advanced"
    }
  ];
  selectedSkill: number = 1; // Initialize to N/A

  patches = [
    {
      id: 0,
      name: "None (Patch Independent)"
    },
    {
      id: 1,
      name: "Latest (1.1.7)"
    },
    {
      id: 2,
      name: "1.1.6"
    },
    {
      id: 3,
      name: "1.1.5"
    }
  ];
  selectedPatch: number = 1; // Initialize to latest patch // TODO: Figure out why not initializing to this

  // TODO: Handle certain special move variations, like KO punch vs normal neutral b?
  moves = [
    {
      id: "1",
      name: "Jab"
    },
    {
      id: "2",
      name: "Dash Attack"
    },
    {
      id: "3",
      name: "Ftilt"
    },
    {
      id: "4",
      name: "Utilt"
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
      linkCtrl: [''],
      bodyCtrl: ['']
    });
    this.additionalFormGroup = this.formBuilder.group({
      patchCtrl: [''],
      tagsCtrl: [''] // TODO: Needs to only allow up to 5 tags, and allow no spaces or special chars per tag
    });
  }

  
  /**
   * Handles when post category selection is changed
   * Determines whether to show or hide additional fields
   */
  onPostCatSelection() {
    // If doing a game-independent post, hide all game-specific controls
    // TODO: Figure out why can't use ===, where's the type difference coming from and how to avoid ==?
    if(this.selectedPostCat == PostEditorComponent.GameIndependentId) {
      this.showGameSpecificFields = false;
      this.showCombosFields = false; // Technically unnecessary but more complete & robust
    }
    else {
      this.showGameSpecificFields = true;

      // Show combos fields only for combo posts
      if(this.selectedPostCat == PostEditorComponent.CombosCatId) {
        this.showCombosFields = true;

        // Set up main character select as required
        this.charSelectTitle = "Performed By Character(s)";
        this.isCharacterRequired = true;
      }
      else {
        this.showCombosFields = false;

        // Character select is optional
        this.charSelectTitle = "Any relevant character(s)?"
        this.isCharacterRequired = false;
      }
    }

    console.log("charSelectTitle: ", this.charSelectTitle);
    console.log("isCharacterRequired", this.isCharacterRequired);
  }

  /**
   * 
   * TODO: Handle multiple character selection
   * @param character Selected character
   */
  onMainCharSelect(character: Character) {
    this.mainCharSelect = character.id;
  }

  /**
   * 
   * TODO: Handle multiple character selection
   * @param character Selected character
   */
  onTargetCharSelect(character: Character) {
    this.targetCharSelect = character.id;
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
        if(isAffirmative) {
          this.stepperComponent.reset();
        }
      });
  }
  
  /**
   * Handles form validation and outputs post data if seems valid
   */
  onSubmitClick() {
    // TODO: Actually do full validation on all form data first before continuing here
    if(!this.isContentFormValid()) {
      // TODO: Show errors to user on screen in appropriate areas

      console.log('Form is invalid so cancelling submit...');
      return;
    }

    // Populate the post to create (id will be generated by service)
    let post: Post = {
      id: -1,

      categoryId: this.selectedPostCat,
      skillEstimateId: this.selectedSkill,
      patchId: this.selectedPatch,
      tags: [this.additionalFormGroup.controls.tagsCtrl.value],

      title: this.contentFormGroup.controls.titleCtrl.value,
      videoUrl: this.contentFormGroup.controls.linkCtrl.value,
      textContent: this.contentFormGroup.controls.bodyCtrl.value 
    };
    // If showing other game fields, use their data as well
    if(this.showGameSpecificFields) {
      post.characterIds = [this.mainCharSelect];

      if(this.showCombosFields) {
        post.targetCharacterIds = [this.targetCharSelect];
        post.comboTypeIds = this.selectedComboType;
        post.targetPercent = this.metaFormGroup.controls.comboPercCtrl.value;
        post.comboDmg = this.metaFormGroup.controls.comboDmgCtrl.value;
        post.comboStarterId = this.selectedComboStarter;
      }
    }

    this.onSubmitHandler.emit(post);
  }
  
  /**
   * Determines if the content-specific form group is valid
   * @returns true if content form valid, false if invalid
   */
  private isContentFormValid(): boolean {
    // Basic validators check
    if(this.contentFormGroup.invalid) return false;
    
    // Post must contain either a video or text at least
    let controls = this.contentFormGroup.controls; // Shortcut
    if(controls.bodyCtrl.value === '' && controls.linkCtrl.value === '') {
      return false;
    }

    // Otherwise, this form is valid
    return true;
  }
}