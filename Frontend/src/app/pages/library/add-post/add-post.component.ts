import { OAuthService } from 'angular-oauth2-oidc';
import { PostSubmission } from './../../../models/PostSubmission';
import { PostService } from './../../../services/post.service';
import { Post } from './../../../models/Post';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { PostEditorComponent } from 'src/app/components/post-editor/post-editor.component';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  @ViewChild('postEditor') editor: PostEditorComponent;
  
  constructor(private titleService: Title,
    private router: Router,
    private postService: PostService,
    private authService: OAuthService) { }

  ngOnInit() {
    if(!this.authService.hasValidAccessToken()) {
      this.router.navigate(['/login']);
    }

    this.titleService.setTitle("Add Post");
  }

  onSubmitHandler(post: Post) {
    let newPost: PostSubmission = {
      category: post.category,
      title: post.title,
      content: post.content,
      featuredLink: post.featuredLink
    }
    console.log("Submitting new post: ", newPost);

    this.postService.createPost(newPost)
    .subscribe(
      newPost => { 
        this.router.navigate(['/library']);

        // Just in case, let the post editor know things are done
        this.editor.onPostSubmit("");
      },
      error =>  { 
        this.editor.onPostSubmit(error);
      }
    );
  }

}
