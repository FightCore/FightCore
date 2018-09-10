import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';

import { BadInputError } from '../errors/bad-input-error';
import { NotFoundError } from '../errors/not-found-error';
import { AppError } from '../errors/app-error';

export abstract class BaseService {

  constructor(protected http: HttpClient) { }

  protected handleError(error: Response) {
    if (error.status === 400)
      return throwError(new BadInputError(error));

    if (error.status === 404)
      return throwError(new NotFoundError());

    return throwError(new AppError(error));
  }

  protected get defaultHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set("Content-Type", "application/json");
    return headers;
  }
}
