import { FakeAuthService } from 'src/app/resources/mockups/fake-auth.service';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

/**
 * Additional layer between application and OAuthService
 */
@Injectable({
  providedIn: 'root'
})
export class AuthBridgeService {

  constructor(private authService: OAuthService) { }

  /**
   * Uses password flow to exchange userName and password for an
   * access_token. After receiving the access_token, this method
   * uses it to query the userinfo endpoint in order to get information
   * about the user in question.
   *
   * When using this, make sure that the property oidc is set to false.
   * Otherwise stricter validations take happen that makes this operation
   * fail.
   *
   * @param userName
   * @param password
   */
  public fetchTokenUsingPasswordFlowAndLoadUserProfile(userName: string, password: string): Promise<object> {
    return AuthBridgeService.isNoBackendEnv() ? 
      FakeAuthService.fetchTokenUsingPasswordFlowAndLoadUserProfile(userName, password) : 
      this.authService.fetchTokenUsingPasswordFlowAndLoadUserProfile(userName, password);
  }

   /**
   * Checkes, whether there is a valid access_token.
   */
  hasValidAccessToken(): boolean {
    return AuthBridgeService.isNoBackendEnv() ? 
      FakeAuthService.hasValidAccessToken() : 
      this.authService.hasValidAccessToken();
  }

  /**
   * Returns the current access_token.
   */
  getAccessToken():string {
    return AuthBridgeService.isNoBackendEnv() ?
      '' : // No non-backend implementation
      this.authService.getAccessToken();
  }

  /**
   * Loads the user profile by accessing the user info endpoint defined by OpenId Connect.
   *
   * When using this with OAuth2 password flow, make sure that the property oidc is set to false.
   * Otherwise stricter validations take happen that makes this operation
   * fail.
   */
  loadUserProfile(): Promise<object> {
    return AuthBridgeService.isNoBackendEnv() ? 
      FakeAuthService.loadUserProfile() : 
      this.authService.loadUserProfile();
  }

  /**
   * Removes all tokens and logs the user out.
   * If a logout url is configured, the user is
   * redirected to it.
   * @param noRedirectToLogoutUrl
   */
  logOut(noRedirectToLogoutUrl?: boolean): void {
    return AuthBridgeService.isNoBackendEnv() ? 
      FakeAuthService.logOut() : 
      this.authService.logOut(noRedirectToLogoutUrl);
  }

  // TODO: Move below to some centralized location?
  static isNoBackendEnv(): boolean {
    return environment.envName === 'noback';
  }
}
