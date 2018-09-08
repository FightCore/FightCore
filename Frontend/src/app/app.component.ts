import { Component } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FightCore';

  private readonly authConfig: AuthConfig = {
    tokenEndpoint: environment.tokenEndpoint,
    userinfoEndpoint: environment.userInfoEndpoint,
    logoutUrl: `${environment.baseUrl}/home`,
    redirectUri: `${environment.baseUrl}/home`,
    oidc: false,
    scope: 'openid profile roles offline_access',
    showDebugInformation: !environment.production,
    requireHttps: environment.production
  }

  constructor(authService: OAuthService) {
    authService.configure(this.authConfig);
  }
}
