import { PostEditAddContentsComponent } from './post-edit-add-contents/post-edit-add-contents.component';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { PopupComponent } from '../popup/popup.component';
import { TabItem } from '../tabs/tab/tab-item';

@Component({
  selector: 'post-edit-add',
  templateUrl: './post-edit-add.component.html',
  styleUrls: ['./post-edit-add.component.css']
})
export class PostEditAddComponent implements OnInit {
  @Output('addPost') addPost = new EventEmitter<number>();
  
  @ViewChild('popup') popup: PopupComponent;
  
  constructor() { }

  ngOnInit() {
  }

  public show() {
    // TODO: Let contents know what posts are already added to save user time
    let postViewer = new TabItem(PostEditAddContentsComponent, "");
    this.popup.show(postViewer,"Add a post");
  }

  onAddChoice(value: number) {
    if(value && typeof value === "number" && value > -1) {
      this.addPost.emit(value);
    }
  }
}
