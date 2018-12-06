import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Post } from 'src/app/models/Post';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ListChangeData } from '../../post-edit-viewer/list-change-data.interface';

@Component({
  selector: 'post-edit-confirm-contents',
  templateUrl: './post-edit-confirm-contents.component.html',
  styleUrls: ['./post-edit-confirm-contents.component.css']
})
export class PostEditConfirmContentsComponent implements OnInit {
  @Input('data') data: ListChangeData;
  @Output('done') done = new EventEmitter<null>(); // TODO: Pass back some form of success/cancel
  
  form: FormGroup;
  isSubmitting: boolean;

  constructor(fb: FormBuilder) {
    this.form = fb.group({
      descriptionCtrl: []
    });
   }

  ngOnInit() {
  }

  onSubmit(): void {
    console.log('Pushed da submit');
  }

  get descriptionCtrl() { return this.form.get('descriptionCtrl'); }
}
