import { PostService } from './../../services/post.service';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Post } from '../../models/Post';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Location } from '@angular/common';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {
  posts: Post[];
  displayPost: Post;
  @ViewChild('postContent') postContent: TemplateRef<any>;

  constructor(private titleService: Title, 
    private router: Router, 
    private location: Location,
    private postService: PostService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.titleService.setTitle("Library");
    this.posts = this.postService.getPosts();
  }
  
  /**
   * Navigates to the add post page
   */
  goToAddPost() {
    this.router.navigate(['/library/add']);
  }

  /**
   * Wrapper for PostService.getPostUrl (don't believe can call static functions from template)
   * TODO: Can we remove this now? Doesn't seem like we need it anymore
   * @param post Post to create url for
   * @returns post url for routerLink 
   */
  getPostUrl(post: Post):string {
    return PostService.getPostUrl(post);
  }

  /**
   * Opens a post view page in a modal popup
   * @param post Represents post whose page to open, assumed to be  valid
   */
  open(post: Post) {
    this.changeUrlForPost(post); // Not actually navigating to post but do this for the browser

    this.displayPost = post; // TODO: Rewrite component to call a method to start getting data and such
    this.modalService.open(this.postContent, {ariaLabelledBy: 'modal-basic-title'})
      // Change the url back once the post is closed
      .result.then((result) => {
        // This side isn't currently used (no save or such action for delegate), but here just in case
        this.changeUrlBack();
      }, (reason) => {
        // This side is for dismissing the view popup (eg, clicking background or X/cross in corner)
        this.changeUrlBack();
      });
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
    // Create the previous location's url (currently only just the base library page with no params)
    let url: string = this.router.createUrlTree(["/library"]).toString();

    // Return the browser to that location
    this.location.go(url);
  }

}
