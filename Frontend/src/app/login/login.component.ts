import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  errorMessage: string;
  isLoading: boolean = false;

  constructor(private titleService: Title, private authService: OAuthService, private router: Router, fb: FormBuilder) { 
    this.form = fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
    if (this.authService.hasValidAccessToken()) {
      this.router.navigate(['/home']);
    }
    this.titleService.setTitle("Login");
  }

  login() {
    this.isLoading = true;
    this.errorMessage = null;
    this.authService.fetchTokenUsingPasswordFlowAndLoadUserProfile(this.email.value, this.password.value)
      .then((tokenResponse => {
        this.router.navigate(['/profile']);
      }))
      .catch(error => {
        this.errorMessage = error.message;
        this.isLoading = false;
      });
  }

  get email(): AbstractControl {
    return this.form.get('email');
  }

  get password(): AbstractControl {
    return this.form.get('password');
  }

}
