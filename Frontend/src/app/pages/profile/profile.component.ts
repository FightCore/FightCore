import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';

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

    this.authService.loadUserProfile().then(
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