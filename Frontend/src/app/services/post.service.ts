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
      { // Combo post mockup

        id: 1,
        // Meta fields
        categoryId: 2,
        characterIds: [2], 

        // Combo specific fields
        targetCharacterIds: [2],
        comboTypeIds: [1,2,3,4,5,6,7],
        targetPercent: 42,
        comboDmg: 10,
        comboStarterId: 2,

        // Additional fields
        skillEstimateId: 1,
        patchId: 1,
        tags: ["First", "Test", "ACombo"],

        // Content fields
        title: "First Test Post",
        videoUrl: "",
        textContent: "Test content here yay"
      },
      { // General post mockup

        id: 2,
        // Meta fields
        categoryId: 1,
        characterIds: [3],

        // Additional fields
        skillEstimateId: 1,
        patchId: 0,
        tags: ["Second", "Test", "Something"],

        // Content fields        
        title: "Second Test Post",
        videoUrl: "",
        textContent: "More test content to write out, gosh dang it"
      },
      { // Game-independent with video

        id: 2,
        // Meta fields
        categoryId: 1,
        
        // Additional fields
        skillEstimateId: 1,
        patchId: 0,
        tags: ["Third", "Test", "Important"],

        // Content fields        
        title: "Third Test Post, Much Importante",
        videoUrl: "https://youtu.be/dQw4w9WgXcQ",
        textContent: "Very important post, mucho importante"
      },
    ];
   }

   public getPosts(): Post[] {
     return this.posts;
   }

   public addPost(post: Post) {
    // TODO: Verify this is a valid post (has all required fields together)

    // Set the id to a unique value. This should be unique every time
    post.id = this.posts[this.posts.length-1].id + 1;

    // Simple behavior before integrating with backend
     this.posts.push(post);
   }
}
