import { PostService } from 'src/app/services/post.service';
import { Character } from './../../models/Character';
import { Post } from './../../models/Post';
import { DialogData } from './../confirm-dialog/dialog-data.interface';
import { ConfirmDialogComponent } from './../confirm-dialog/confirm-dialog.component';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormControl } from '@angular/forms';
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
  styleUrls: ['./post-editor.component.scss']
})
export class PostEditorComponent implements OnInit {
  @ViewChild('editor') editor: EditorComponent;

  title = new FormControl('');
  ngOnInit(): void {
  }
}
