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
    private postService: PostService) { }

  ngOnInit() {
    this.titleService.setTitle("Add Post");
  }

  onSubmitHandler(post: Post) {
    this.postService.addPost(post);

    // TODO: On success, navigate to the created post page instead of just the library page
    this.router.navigate(['/library']);
  }

}
