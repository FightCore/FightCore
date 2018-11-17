import { AuthBridgeService } from './auth-bridge.service';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

export abstract class BaseAuthGuard implements CanActivate {

  constructor(protected router: Router, protected authService: AuthBridgeService) { }

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
