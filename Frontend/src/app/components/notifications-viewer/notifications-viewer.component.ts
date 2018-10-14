import { environment } from './../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'notifications-viewer',
  templateUrl: './notifications-viewer.component.html',
  styleUrls: ['./notifications-viewer.component.css']
})
export class NotificationsViewerComponent implements OnInit {
  msgs = [];
  errorMsg: string;
  username: string;
  isLoading: boolean;

  constructor(private authService: OAuthService) { }

  ngOnInit() {
    this.isLoading = true;
    this.authService.loadUserProfile().then(
      obj => {
        this.isLoading = false;

        let returnObj = obj as any; // Can't access Object's properties directly, being extra careful here
        if(returnObj.hasOwnProperty('username')) {
          this.username = returnObj.username;
          this.startNotifHub();
        }
        else {
          this.errorMsg = "Object return is missing username!"
          console.log(this.errorMsg);
        }
      },
      reason => { 
        this.isLoading = false;

        this.errorMsg = "Getting username was rejected. Token invalid now? Try logging in again";
        console.log(this.errorMsg, reason);
      }
    );
  }

  startNotifHub() {
    // Create an authorized connection
    let test = new HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/notify`, { accessTokenFactory: () => this.authService.getAccessToken() })
      .build();
    
    // Simple test on backend's BroadcastMessage method
    test.on('BroadcastMessage', (type: string, payload: string) => {
      this.msgs.push({severity: type, summary: payload});
    });

    // Start the connection at the end to avoid any possible missed messages
    test.start()
      .then(() => console.log('Connection started!'))
      .catch(err => {
        console.log('Error while establishing connection: ', err
      )});
  }

}
