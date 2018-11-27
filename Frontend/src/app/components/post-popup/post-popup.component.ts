import { TabItem } from './../tabs/tab/tab-item';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Post } from '../../models/Post';
import { Location } from '@angular/common';
import { PostService } from 'src/app/services/post.service';
import { Router } from '@angular/router';
import { PopupComponent } from '../popup/popup.component';
import { PostViewerComponent } from '../post-viewer/post-viewer.component';

@Component({
  selector: 'post-popup',
  templateUrl: './post-popup.component.html',
  styleUrls: ['./post-popup.component.css']
})
export class PostPopupComponent implements OnInit {
  @ViewChild('popup') popup: PopupComponent;

  /**
   * Stores the previous url used before displaying this post. Used to reset url after post is closed 
   */
  previousUrl: string;

  constructor(private location: Location, private router: Router) { }

  ngOnInit() {
  }

  public openPopup(post: Post) {
    this.changeUrlForPost(post);

    let postViewer = new TabItem(PostViewerComponent, post);
    this.popup.show(postViewer, "");
  }

  /**
   * Changes browser url for the given post (no router navigation)
   * @param post 
   */
  changeUrlForPost(post: Post) {
    this.previousUrl = this.router.url; // Need to restore url after post closes

    // Actually change the url for the post (SEO + user friendliness reasons)
    post.urlName = PostService.createUrlName(post.title); // TODO: Shouldn't be necessary!
    let url: string = PostService.getPostUrl(post);
    this.location.go(url);
  }

  /**
   * Changes the url back to what it was before viewing a post
   * Called when popup is closed (see template)
   */
  changeUrlBack() {
    if(!this.previousUrl) {
      // TODO: Log an error of some sort
      console.log("Original Url not set");
      return;
    }

    // Return the browser to the original location
    this.location.go(this.previousUrl);
  }
}
