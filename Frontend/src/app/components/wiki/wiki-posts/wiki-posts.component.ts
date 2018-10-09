import { PostPopupComponent } from './../../post-popup/post-popup.component';
import { WikiComponentInterface } from './../wiki-component.interface';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Post } from '../../../models/Post';

@Component({
  selector: 'wiki-posts',
  templateUrl: './wiki-posts.component.html',
  styleUrls: ['./wiki-posts.component.css']
})
export class WikiPostsComponent implements OnInit, WikiComponentInterface {
  @Input('data') data: Post[];

  @ViewChild('postPopup') postPopup: PostPopupComponent;

  constructor() { }

  ngOnInit() {
  }

   /**
   * Opens a post view page in a modal popup
   * @param post Represents post whose page to open, assumed to be  valid
   */
  open(post: Post) {
    this.postPopup.openPopup(post);
  }

}