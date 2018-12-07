import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { FakePostListService } from '../resources/mockups/fake-post-list.service';
import { PostList } from '../models/PostList';
import { EditSuggestion } from '../models/EditSuggestion';
import { SuggestionList } from '../models/SuggestionList';

@Injectable({
  providedIn: 'root'
})
export class PostListService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getPostList(listId: number): Observable<PostList> {
    if(environment.envName === 'noback') {
      return FakePostListService.getPostList(listId);
    }
    
    throw new Error('Not yet implemented');
  }

  public getPendingSuggestions(listId: number): Observable<SuggestionList> {
    if(environment.envName === 'noback') {
      return FakePostListService.getPendingSuggestions(listId);
    }
    
    throw new Error('Not yet implemented');
  }

  public createEdit(listId: number, changes: any): Observable<null> {
    throw new Error('Not yet implemented');
  }
  public createSuggestion(listId: number, changes: any): Observable<null> {
    throw new Error('Not yet implemented');
  }
  public acceptSuggestion(suggId: number, changes: any): Observable<null> {
    throw new Error('Not yet implemented');
  }
  public denySuggestion(suggId: number, changes: any): Observable<null> {
    throw new Error('Not yet implemented');
  }
  public requestSuggestionChanges(suggId: number, changes: any): Observable<null> {
    throw new Error('Not yet implemented');
  }
}
