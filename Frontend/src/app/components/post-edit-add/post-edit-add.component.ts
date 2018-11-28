import { Post } from 'src/app/models/Post';
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
  @Output('addPost') addPost = new EventEmitter<Post>();
  
  @ViewChild('popup') popup: PopupComponent;
  
  constructor() { }

  ngOnInit() {
  }

  public show() {
    // TODO: Let contents know what posts are already added to save user time
    let postViewer = new TabItem(PostEditAddContentsComponent, "");
    this.popup.show(postViewer,"Add a post");
  }

  onAddChoice(post: Post) {
    if(post && post.id > 0) {
      this.addPost.emit(post);
    }
  }
}
