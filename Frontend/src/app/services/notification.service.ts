import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { NotificationsResponse } from '../models/NotificationsResponse';

@Injectable()
export class NotificationService extends BaseService {

  constructor(http: HttpClient) { 
    super(http);
  }

  getPage(pageNumber: number): Observable<NotificationsResponse> {
    return this.http.get<NotificationsResponse>(
      `${environment.baseUrl}/Notifications/${pageNumber}`,
      {headers: this.defaultHeaders} )
      .pipe(catchError(this.handleError));
  }

  markAllRead() {
    this.http.post(`${environment.baseUrl}/notifications`, "")
      .pipe(catchError(this.handleError))
      .subscribe();
  }

  markSingleRead(id: number) {
    this.http.post(`${environment.baseUrl}/notifications/${id}`, "")
      .pipe(catchError(this.handleError))
      .subscribe();      
  }
}
