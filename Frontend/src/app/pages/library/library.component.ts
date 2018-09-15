import { PostService } from './../../services/post.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Post } from '../../models/Post';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {
  posts: Post[];

  constructor(private titleService: Title, private router: Router, 
    private postService: PostService) { }

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

}
