import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UserService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.baseUrl}/users`, { headers: this.defaultHeaders })
      .pipe(catchError(this.handleError));
  }
}
