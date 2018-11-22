import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { PostsPage } from '../models/PostsPage';
import { FakeDashboardService } from '../resources/mockups/fake-dashboard.service';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }
  /**
   * Gets posts for a dashboard widget
   * @param sortId 
   * @param category Only element currently used
   * @param characterId 
   * @param [pageOrSpecialTypeInfo] Placeholder for additional info regarding specific page or if a special type of post list
   * @returns posts A page of posts representing a dashboard for inputs
   */
  public getPosts(sortId: number, category: number, characterId:  number, pageOrSpecialTypeInfo?: any): Observable<PostsPage> {
    if(environment.envName === 'noback') {
      return FakeDashboardService.getPosts(sortId, category, characterId);
    }
    
    throw new Error('Not yet implemented');
  }
}
