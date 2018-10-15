import { environment } from './../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { Notification } from 'src/app/models/Notification';

@Component({
  selector: 'notifications-viewer',
  templateUrl: './notifications-viewer.component.html',
  styleUrls: ['./notifications-viewer.component.css']
})
export class NotificationsViewerComponent implements OnInit {
  msgs: Notification[] = [];
  errorMsg: string;
  username: string;
  isLoading: boolean;

  constructor(private authService: OAuthService, private router: Router) { }

  ngOnInit() {
    // Get the current username (not currently stored anywhere besides in token)
    this.isLoading = true;
    console.log("Starting connection process");
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
    let connection = new HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/notify`, { accessTokenFactory: () => this.authService.getAccessToken() })
      // TODO: Decide if modifying or removing below. Chrome has some default errors always which makes it a pain...
      // .configureLogging({
      //   log: (logLevel, message) => {
      //     if(logLevel <= LogLevel.Information) {
      //       return; // Not worth the effort
      //     }
      //     else {
      //       console.log("Connection logging:", logLevel, message);
      //       if(logLevel >= LogLevel.Warning) { // Only display errors, not warnings
      //         this.errorMsg = message;
      //       }
      //     }
      //   }
      // })
      .build();

    // Handle receiving notifications from server
    connection.on('BroadcastNotification',
    (notif: Notification) => {
      this.msgs.push(notif);
    });

    // Start the connection at the end to avoid any possible missed messages
    connection.start()
      .then(() => console.log('Connection started!'))
      .catch(err => {
        this.errorMsg = 'Error while establishing connection';
        console.log('Error while establishing connection: ', err)
      });
  }

}
