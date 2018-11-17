import { AuthBridgeService } from './auth-bridge.service';
import { Injectable } from '@angular/core';
import { BaseAuthGuard } from './base-auth-guard.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthGuard extends BaseAuthGuard {

  constructor(router: Router, authService: AuthBridgeService) {
    super(router, authService);
  }

  get isAuthorized(): boolean {
    return true;
  }
}
