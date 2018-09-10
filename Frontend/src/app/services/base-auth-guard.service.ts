import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';

export abstract class BaseAuthGuard implements CanActivate {

  constructor(protected router: Router, protected authService: OAuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

		if (this.authService.hasValidAccessToken() && this.isAuthorized) {
			return true;
		}

		this.router.navigate(['/login']);
		return false;
	}

  // The base classes can have specific implementations for isAuthorized for example based on the role of the user
	abstract get isAuthorized(): boolean
}
