import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ListChangeData } from '../../post-edit-viewer/post-edit-viewer-changes/post-edit-viewer-changes.component';
import { Post } from 'src/app/models/Post';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'post-edit-confirm-contents',
  templateUrl: './post-edit-confirm-contents.component.html',
  styleUrls: ['./post-edit-confirm-contents.component.css']
})
export class PostEditConfirmContentsComponent implements OnInit {
  @Input('data') data: Post[]; // Final list of posts for previewing
  @Output('done') done = new EventEmitter<null>(); // TODO: Pass back some form of success/cancel
  changeData: ListChangeData;
  
  form: FormGroup;
  isSubmitting: boolean;

  constructor(fb: FormBuilder) {
    this.form = fb.group({
      descriptionCtrl: []
    });
   }

  ngOnInit() {
    // TODO Testing
    this.changeData = {
      totalAdded: 0,
      totalRemoved: 0
    };
  }

  onSubmit(): void {
    console.log('Pushed da submit');
  }

  get descriptionCtrl() { return this.form.get('descriptionCtrl'); }
}
