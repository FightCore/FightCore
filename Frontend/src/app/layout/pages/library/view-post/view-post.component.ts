import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/Post';
import { PostService } from 'src/app/services/post.service';

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
      this.post = PostService.getBasicPost();
      this.post.id = params['id'];

      // Try getting the post with the given id
      // TODO: Remove all this, post-viwer is already going to get all this info. Create a way to get info from the post-viewer itself
      this.postService.getPost(params['id']).subscribe((res: Post) => {
        res.urlName = PostService.createUrlName(res.title); // TODO: Remove this line once server actually does this
        //For SEO reasons, postName must match post
        if(res.urlName !== params['postName']) {
          this.onNavigateError();
          return;
        }

        this.post = res;
      }, error => {
        this.onNavigateError();
      });
    });
  }

  /**
   * Handles if there's a navigation error
   */
  onNavigateError() {
    // For now, just go to 404 page (via navigating to any invalid page)
    // TODO: Either create a new 404 page or pass in specific helpful info to the 404 page
    this.router.navigate(['/post-not-found'], { skipLocationChange: true });
  }

}
