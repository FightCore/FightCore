import { PostService } from './../../../services/post.service';
import { Post } from './../../../models/Post';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-post',
  templateUrl: './view-post.component.html',
  styleUrls: ['./view-post.component.css']
})
export class ViewPostComponent implements OnInit {
  post: Post;

  constructor(private route: ActivatedRoute, 
    private router: Router,
    private postService: PostService) { }

  ngOnInit() {
    // Get params
    this.route.params.subscribe((params: Params) => {
      console.log("Got params: ", params);
      this.post = PostService.getBasicPost();
      this.post.id = params['id'];

      // Try getting the post with the given id
      this.postService.getPost(params['id']).subscribe((res: Post) => {
        this.post = res;
      });
      // if(!post) {
      //   this.onNavigateError();
      //   return;
      // }

      // For SEO reasons, postName must match post
      // if(post.urlName !== params['postName']) {
      //   this.onNavigateError();
      //   return;
      // }

      // Finally, finish setting up as we know the post is definitely valid now
      //this.post = post;
    });
  }

  /**
   * Handles if there's a navigation error
   */
  onNavigateError() {
    // For now, just go to 404 page (via navigating to any invalid page)
    // TODO: Either create a new 404 page or pass in specific helpful info to the 404 page
    console.log("onNavigateError");
    this.router.navigate(['/post-not-found'], { skipLocationChange: true });
  }

}
