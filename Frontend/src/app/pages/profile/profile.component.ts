import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { FakeAuthService } from 'src/app/resources/mockups/fake-auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  username: string;

  constructor(private titleService: Title, private authService: OAuthService, private router: Router) { }

  ngOnInit() {
    this.titleService.setTitle("Profile");

    let authPromise: Promise<object> = environment.envName === 'noback' ? 
      FakeAuthService.loadUserProfile() : 
      this.authService.loadUserProfile();

    authPromise.then(
      obj => {
        let returnObj = obj as { username: string }; // Can't access Object's properties directly, being extra careful here
        if(returnObj.username) {
          this.username = returnObj.username;
        }
        else {
          console.log("Object return is missing username!");
          this.username = "[Failed to get username]";
        }
      },
      reason => { 
        this.username = "[Failed to get username]";
        console.log("Rejected: ", reason) 
      }
    );
  }

}