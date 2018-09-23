import { PostService } from './../../services/post.service';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Post } from '../../models/Post';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

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
   * @param post Post to create url for
   * @returns post url for routerLink 
   */
  getPostUrl(post: Post):string {
    return PostService.getPostUrl(post);
  }

  open(post: Post) {
    this.displayPost = post; // TODO: Rewrite component to call a method to start getting data and such
    this.modalService.open(this.postContent, {ariaLabelledBy: 'modal-basic-title'});
  }

}
