import { OAuthService } from 'angular-oauth2-oidc';
import { IPostSubmission } from './../../../models/PostSubmission';
import { PostService } from './../../../services/post.service';
import { Post } from './../../../models/Post';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {

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
    let newPost: IPostSubmission = {
      id: 0,
      author: {
          email: "",
          userName: ""
      },
      authorId: 1,
      content: post.content,
      featuredLink: post.featuredLink,
      title: post.title,
      createdDate: "2018-10-12T01:35:54.927Z",
      lastEdit: "2018-10-12T01:35:54.927Z",
      skillLevel: post.skillLevel,
      views: 0,
      category: post.category,
      patchId: post.patchId
    }
    console.log("Submitting new post: ", newPost);

    this.postService.createPost(newPost)
    .subscribe(
      newPost => { 
        this.router.navigate(['/library']);
      },
      error => console.log("Failed creating new post, error: ", error) // TODO: Show an error message to user
    );
  }

}
