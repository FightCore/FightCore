import { FakeAuthService } from 'src/app/resources/mockups/fake-auth.service';
import { environment } from 'src/environments/environment';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  constructor(private titleService: Title, private authService: OAuthService, private router: Router) { 
  }

  ngOnInit() {
    let isLoggedIn: boolean = environment.envName === 'noback' ? 
      FakeAuthService.hasValidAccessToken() : 
      this.authService.hasValidAccessToken();
    if (isLoggedIn) {
      this.router.navigate(['/home']);
    }
    this.titleService.setTitle("Login");
  }

}
