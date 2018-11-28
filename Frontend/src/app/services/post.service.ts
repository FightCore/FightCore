import { environment } from './../../environments/environment';
import { PostSubmission } from './../models/PostSubmission';
import { Injectable } from '@angular/core';
import { Post } from '../models/Post';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { PostsPage } from '../models/PostsPage';
import { FakePostService } from '../resources/mockups/fake-post.service';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
  }

  /**
   * Gets a base Post object (TODO: Make Post a class at this point!)
   * @returns url for routerLink representing this post 
   */
  public static getBasicPost(): Post {
    return {
      id: -1,
      authorId: -1,
      author: null,
      createdDate: new Date(),
      views: -1,
      rating: -1,
      urlName: '',
      category: -1,
      skillLevel: -1,
      patchId: -1,
      title: ''
    };
  }

  /**
  * Create the post name that will show up in the url
  * Note: This should be done on the server. Here for mockup purposes
  * @param title Represents post title to create url name off of
  * @returns String that should go in the url
  */
  public static createUrlName(title: string): string {
    // First remove all characters except alphanumeric and space
    title = title.replace(/[^\w\s]/gi, ''); // Technically allows spaces, tabs, etc
    // Then replace spaces with tabs and make all lowercase
    title = title.replace(/\s+/g, '-').toLowerCase();

    // Also need to limit the length and make sure not starting or ending with dash
    // But will leave that to backend

    return title;
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
    if(environment.envName === 'noback') {
      return FakePostService.getPost(id);
    }
    
    return this.http.get<Post>(`${environment.baseUrl}/library/${id}`, { headers: this.defaultHeaders })
      .pipe(catchError(this.handleError));
  }

  public getPostsPage(pageSize: number, pageNumber: number, sortId: number, category: number): Observable<PostsPage> {
    if(environment.envName === 'noback') {
      return FakePostService.getPostsPage();
    }
    
    let params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString())
      .set('sortOption', sortId.toString())
      .set('categoryFilter', category.toString());
    
    return this.http.get<PostsPage>(
      `${environment.baseUrl}/library`,
      { headers: this.defaultHeaders, params: params })
      .pipe(catchError(this.handleError));
  }

  public findPostsByTitle(search: string): Observable<Post[]> {
    if(environment.envName === 'noback') {
      return FakePostService.findPostsByTitle(search);
    }

    throw new Error('Not yet implemented');
  }

  public createPost(newPost : PostSubmission): Observable<Post> {
    if(environment.envName === 'noback') {
      return FakePostService.createPost(newPost);
    }

    return this.http.post<Post>(`${environment.baseUrl}/library`, newPost, {headers: this.defaultHeaders})
      .pipe(catchError(this.handleError));
  }
}
