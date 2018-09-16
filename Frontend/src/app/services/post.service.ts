import { Injectable } from '@angular/core';
import { Post } from '../models/Post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private posts: Post[];

  constructor() {
    // Initialize mockup posts
    this.posts = [
      {
        id: 1,
        title: "First Test Post",
        content: "Test content here yay"
      },
      {
        id: 2,
        title: "Second Test Post",
        content: "More test content to write out, gosh dang it"
      }
    ];
   }

   public getPosts(): Post[] {
     return this.posts;
   }

   public addPost(post: Post) {
    // Set the id to a unique value. This should be unique every time
    post.id = this.posts[this.posts.length-1].id + 1;

    // Simple behavior before integrating with backend
     this.posts.push(post);
   }
}
