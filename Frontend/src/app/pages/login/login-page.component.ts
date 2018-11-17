import { AuthBridgeService } from './../../services/auth-bridge.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  constructor(private titleService: Title, private authService: AuthBridgeService, private router: Router) { 
  }

  ngOnInit() {
    if (this.authService.hasValidAccessToken()) {
      this.router.navigate(['/home']);
    }
    this.titleService.setTitle("Login");
  }

}
