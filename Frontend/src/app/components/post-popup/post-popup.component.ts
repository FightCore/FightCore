import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Post } from '../../models/Post';
import { Location } from '@angular/common';
import { PostService } from 'src/app/services/post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'post-popup',
  templateUrl: './post-popup.component.html',
  styleUrls: ['./post-popup.component.css']
})
export class PostPopupComponent implements OnInit {
  displayPost: Post;
  @ViewChild('postContent') postContent: TemplateRef<any>;

  previousUrl: string;

  constructor(private modalService: NgbModal,
    private location: Location,
    private router: Router) { }

  ngOnInit() {
  }

  public openPopup(post: Post) {
    this.previousUrl = this.router.url;

    this.changeUrlForPost(post);
    this.displayPost = post;

    this.modalService.open(this.postContent, 
      {
        size: 'lg',
        windowClass: 'post-modal' 
      })
      // Change the url back once the post is closed
      .result.then((result) => {
        // This side isn't currently used (no save or such action for delegate), but here just in case
        this.changeUrlBack();
      }, (reason) => {
        // This side is for dismissing the view popup (eg, clicking background or X/cross in corner)
        this.changeUrlBack();
      }
    );
  }

  /**
   * Changes browser url for the given post (no router navigation)
   * @param post 
   */
  changeUrlForPost(post: Post) {
    let url: string = PostService.getPostUrl(post);
    this.location.go(url);
  }

  /**
   * Changes the url back to what it was before viewing a post
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
