import { Injectable } from '@angular/core';
import { Post } from '../models/Post';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BaseService } from './base.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService {
  private posts: Post[];

  constructor(http: HttpClient) {
    super(http);
    // Initialize mockup posts
    this.posts = [
      { // Combo post mockup

        id: 1,
        authorId: 1,
        createdDate: new Date(),
        views: 22,
        rating: 0,
        urlName: "first-test-post",
        
        // Meta fields
        category: 2,
        characterIds: [2], 

        // Combo specific fields
        targetCharacterIds: [2],
        comboTypeIds: [1,2,3,4,5,6,7],
        targetPercent: 42,
        comboDmg: 10,
        comboStarterId: 2,

        // Additional fields
        skillLevel: 1,
        patchId: 1,
        tags: ["First", "Test", "ACombo"],

        // Content fields
        title: "First Test Post",
        featuredLink: "",
        content: "Test content here yay"
      },
      { // General post mockup

        id: 2,
        authorId: 2,
        createdDate: new Date('December 7, 1995 03:24:00'),
        views: 404,
        rating: 42,
        urlName: "second-test-post",

        // Meta fields
        category: 1,
        characterIds: [3],

        // Additional fields
        skillLevel: 1,
        patchId: 0,
        tags: ["Second", "Test", "Something"],

        // Content fields        
        title: "Second Test Post",
        featuredLink: "",
        content: "More test content to write out, gosh dang it"
      },
      { // Game-independent with video

        id: 3,
        authorId: 3,
        createdDate: new Date('January 8, 2017 12:24:00'),
        views: 22,
        rating: -2,
        urlName: "third-test-post",

        // Meta fields
        category: 6,
        
        // Additional fields
        skillLevel: 1,
        patchId: 0,
        tags: ["Third", "Test", "Important"],

        // Content fields        
        title: "Third Test Post, Much Importante",
        featuredLink: "https://youtu.be/dQw4w9WgXcQ",
        content: "Very important post, mucho importante"
      },
    ];
  }

  /**
   * Gets a base Post object (TODO: Make Post a class at this point!)
   * @returns url for routerLink representing this post 
   */
  public static getBasicPost(): Post {
    return {
      id: -1,
      authorId: -1,
      createdDate: new Date(),
      views: -1,
      rating: -1,
      urlName: '',
      category: -1,
      skillLevel: -1,
      patchId: -1,
      tags: [],
      title: ""
    };
  }

  /**
   * Gets direct post url
   * @param post Post to create url for
   * @returns url for routerLink representing this post 
   */
  public static getPostUrl(post: Post): string {
    return '/library/' + post.id + '/' + post.urlName;
  }

  public getPost(id: number): Observable<Post> {
    return this.http.get<Post>(`https://localhost:5001/library/${id}`, { headers: this.defaultHeaders }).pipe(catchError(this.handleError));
    //return this.posts.find((post: Post) => post.id == id); // Not sure why can't use ===
  }

  public getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`https://localhost:5001/library`, { headers: this.defaultHeaders }).pipe(catchError(this.handleError));
  }

  public addPost(post: Post) {
    // TODO: Verify this is a valid post (has all required fields together)
    // Correction: The above TODO should be done elsewhere, not in addPost

    // Note: Below few lines should be done on server
    post.id = this.posts[this.posts.length-1].id + 1; // Set the id to a unique value
    post.urlName = this.createUrlName(post.title);
    post.createdDate = new Date();
    post.views = 0;
    post.rating = 0;

    // Simple behavior before integrating with backend
    this.posts.push(post);
  }
  
  /**
  * Create the post name that will show up in the url
  * Note: This should be done on the server. Here for mockup purposes
  * @param title Represents post title to create url name off of
  * @returns String that should go in the url
  */
  private createUrlName(title: string): string {
  // First remove all characters except alphanumeric and space
  title = title.replace(/[^\w\s]/gi, ''); // Technically allows spaces, tabs, etc
  // Then replace spaces with tabs and make all lowercase
  title = title.replace(/\s+/g, '-').toLowerCase();

  // Also need to limit the length and make sure not starting or ending with dash
  // But will leave that to backend

    return title;
  }
}
