import { PostService } from './../../services/post.service';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Post } from '../../models/Post';
import { PostPopupComponent } from '../../components/post-popup/post-popup.component';
import { PageEvent } from '@angular/material';
import { PostFiltersStatus } from 'src/app/components/post-filters/post-filters.component';
import { PostPreview } from 'src/app/models/PostPreview';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.scss']
})
export class LibraryComponent implements OnInit {
  posts: PostPreview[] = [];
  displayPost: PostPreview;
  @ViewChild('postContent') postContent: TemplateRef<any>;
  @ViewChild('postPopup') postPopup: PostPopupComponent;

  isLoading: boolean;
  errorMsgs = [];

  // Paginator
  pageNumber = 1;
  pageSize = 10; // Default page size
  totalPosts = 0;
  sortOption = 0; // TODO

  constructor(private titleService: Title, 
    private router: Router, 
    private postService: PostService) { }

  ngOnInit() {
    this.titleService.setTitle("Library");
    
    this.loadPosts();
  }

  loadPosts() {
    // Show loading indicator and clear any extra error messages
    this.isLoading = true;
    this.errorMsgs = [];

    this.postService.getPostsPage(this.pageSize, this.pageNumber, this.sortOption).subscribe(
      postsPage => {
        this.isLoading = false;
        
        // Store useful results
        this.totalPosts = postsPage.total;
        this.posts = postsPage.posts;

        // Set these in order to be robust
        this.pageSize = postsPage.pageSize;
        this.pageNumber = postsPage.pageNumber;       
        // TODO: Pass back sort and filters as well?   
      },
      error => {
        this.isLoading = false;
        this.errorMsgs.push(error);
        console.log("Error on post page", error);
      }
    );
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
   * @param post Represents post whose page to open, assumed to be valid
   */
  open(post: Post) {
    this.postPopup.openPopup(post);
  }

  onPageChange(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.pageNumber = event.pageIndex + 1;

    this.loadPosts();
  }

  onSortChange(sortId: number) {
    this.sortOption = sortId;

    this.loadPosts();
  }

  onFiltersChange(filters: PostFiltersStatus) {
    console.log("Post filters changed", filters);
  }

}
