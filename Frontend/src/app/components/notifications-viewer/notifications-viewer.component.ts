import { environment } from './../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import { OAuthService } from 'angular-oauth2-oidc';
import { Notification } from 'src/app/models/Notification';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'notifications-viewer',
  templateUrl: './notifications-viewer.component.html',
  styleUrls: ['./notifications-viewer.component.css']
})
export class NotificationsViewerComponent implements OnInit {
  isLoadingNotifications: boolean;
  isLoadingPushService: boolean;
  
  username: string;
  errorMsgs = [];
  totalNotifs: number = -1;
  
  notifs: Notification[] = [];

  constructor(
    private authService: OAuthService,
    private notifService: NotificationService) { }

  // TODO: Better handle possibility of getting push notif while getting current notifs

  ngOnInit() {
    // Get first page of notifications
    this.isLoadingNotifications = true;
    this.notifService.getPage(1)
      .subscribe(
        response => {
          this.isLoadingNotifications = false;
          
          this.notifs = this.notifs.concat(response.notifications);
          this.totalNotifs = response.totalNotifications;
        },
        error => {
          this.isLoadingNotifications = false;
          this.errorMsgs.push("Failed to get current notifications");
          console.log("Error getting current notifs: ", error);
        }
      )

    // Get the current username (not currently stored anywhere besides in token)
    this.isLoadingPushService = true;
    console.log('Starting connection process');
    this.authService.loadUserProfile().then(
      obj => {
        let returnObj = obj as any; // Can't access Object's properties directly, being extra careful here
        if(returnObj.hasOwnProperty('username')) {
          this.username = returnObj.username;
          this.startPushNotifHub();
        }
        else {
          this.errorMsgs.push('Object return is missing username!')
          console.log('Object return is missing username!');
        }
      },
      reason => { 
        this.isLoadingPushService = false;

        this.errorMsgs.push('Getting username was rejected. Token invalid now? Try logging in again');
        console.log('Getting username was rejected', reason);
      }
    );
  }

  /**
   * Sets up connection to get push notifications
   */
  private startPushNotifHub() {
    // Create an authorized connection
    let connection = new HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/notify`, { accessTokenFactory: () => this.authService.getAccessToken() })
      .build();

    // Handle receiving notifications from server
    connection.on('BroadcastNotification',
    (notif: Notification) => {
      this.handleNewNotification(notif);
    });

    // Start the connection at the end to avoid any possible missed messages
    connection.start()
      .then(() => console.log('Connection started!'))
      .catch(err => {
        this.errorMsgs.push('Error while establishing connection')
        console.log('Error while establishing connection: ', err)
      });
    this.isLoadingPushService = false;
  }

  /**
   * Handles receiving a new notification
   * @param notif New notification
   */
  private handleNewNotification(notif: Notification) {
    console.log(notif);
    this.notifs.push(notif);
  }

}
