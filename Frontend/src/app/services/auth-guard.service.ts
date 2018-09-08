import { Injectable } from '@angular/core';
import { BaseAuthGuard } from './base-auth-guard.service';
import { Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';


@Injectable()
export class AuthGuard extends BaseAuthGuard {

  constructor(router: Router, authService: OAuthService) {
    super(router, authService);
  }

  get isAuthorized(): boolean {
    return true;
  }
}
