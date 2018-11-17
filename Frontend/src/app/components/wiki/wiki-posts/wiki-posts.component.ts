import { WikiInfoComponent } from './../wiki-info/wiki-info.component';
import { PostPopupComponent } from './../../post-popup/post-popup.component';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Post } from '../../../models/Post';

@Component({
  selector: 'wiki-posts',
  templateUrl: './wiki-posts.component.html',
  styleUrls: ['./wiki-posts.component.scss']
})
export class WikiPostsComponent implements OnInit {
  @Input('header') header: string;
  postList: Post[];

  @ViewChild('postPopup') postPopup: PostPopupComponent;
  @ViewChild('wikiInfo') wikiInfo: WikiInfoComponent;

  isLoading: boolean; // Shows loading indicator for user

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

  public nowLoadingPosts() {
    this.isLoading = true;
  }

  public doneLoadingPosts(posts: Post[]) {
    this.postList = posts;
    this.wikiInfo.setPostList(posts);
    
    this.isLoading = false;
  }

}