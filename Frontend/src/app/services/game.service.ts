import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Game } from '../models/Game';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService extends BaseService {

  constructor(http: HttpClient) { 
    super(http);
  }

  getAll(): Observable<Game[]>{
    return this.http.get<Game[]>(`${environment.baseUrl}/games`,  { headers: this.defaultHeaders })
      .pipe(catchError(this.handleError));
  }
}
