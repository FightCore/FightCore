import { Router } from '@angular/router';
import { environment } from './../../../environments/environment';
import { Component, OnInit, Input } from '@angular/core';
import { HubConnectionBuilder, LogLevel, HubConnection } from '@aspnet/signalr';
import { OAuthService } from 'angular-oauth2-oidc';
import { Notification } from 'src/app/models/Notification';
import { NotificationService } from 'src/app/services/notification.service';
import { PageEvent } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import { TabComponentInterface } from '../tabs/tab/tab-component.interface';


@Component({
  selector: 'notifications-viewer',
  templateUrl: './notifications-viewer.component.html',
  styleUrls: ['./notifications-viewer.component.scss']
})
export class NotificationsViewerComponent implements OnInit, TabComponentInterface {

  // These are set from server
  static readonly BROADCAST_NAME = 'BroadcastNotification';
  static readonly PAGE_SIZE = 20; // Can't make static as template can't read it

  // Limits for toast notification (currently just guessimating good numbers)
  static readonly TOAST_MAX_TITLE_LENGTH = 25;
  static readonly TOAST_MAX_CONTENT_LENGTH = 100;

  @Input('data') data; // Unused for the moment



  connection: HubConnection;
  isLoadingNotifications: boolean;
  isLoadingPushService: boolean;
  errorMsgs = [];
  username: string;

  notifs: Notification[] = [];
  totalNotifs: number = 0;
  currentPage = 1;

  constructor(
    private authService: OAuthService,
    private router: Router,
    private notifService: NotificationService,
    private toastr: ToastrService) { }

  // TODO Issue 28: Better handle possibility of getting push notif while getting current notifs

  ngOnInit() {
    // Get first page of notifications
    this.retrieveNotificationsPage(1);

    // Get the current username (not currently stored anywhere besides in token)
    this.isLoadingPushService = true;
    console.log('Starting connection process');
    this.authService.loadUserProfile().then(
      obj => {
        let returnObj = obj as any; // Can't access Object's properties directly, being extra careful here
        if (returnObj.hasOwnProperty('username')) {
          this.username = returnObj.username;
          this.startPushNotifHub();
        } else {
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

  ngOnDestroy() {
    // Clean up the push notif connection. Otherwise, may end up keeping multiple handlers remaining over time
    if (this.connection) {
      this.connection.off(NotificationsViewerComponent.BROADCAST_NAME);
      this.connection.stop();
    }
  }

  onPageChange(pageEvent: PageEvent) {
    // Server uses index of 1 for first page while paginator uses 0
    this.retrieveNotificationsPage(pageEvent.pageIndex + 1);
  }

  /**
   * Shows a toast notification to user
   * @param notif Notification to display as a toast
   */
  showToastNotification(notif: Notification) {
    // Trim title and content if appropriate
    let title: string;
    if (notif.title.length > NotificationsViewerComponent.TOAST_MAX_TITLE_LENGTH) {
      title = notif.title.substring(0, NotificationsViewerComponent.TOAST_MAX_TITLE_LENGTH)
              + '...';
    } else {
      title = notif.title;
    }
    let content: string;
    if (notif.content.length > NotificationsViewerComponent.TOAST_MAX_CONTENT_LENGTH) {
      content = notif.content.substring(0, NotificationsViewerComponent.TOAST_MAX_CONTENT_LENGTH)
              + '...';
    } else {
      content = notif.content;
    }

    // Show the toast notification
    let activeToast = this.toastr.info(content, title, {
      positionClass: 'toast-bottom-right',
      progressBar: true,
      progressAnimation: 'increasing',
      closeButton: true
    });

    // Handle if the user clicks on the notification
    activeToast.onTap.subscribe(
      () => {
        this.onNotifClick(notif);
      },
      error => console.log('Why the heck would there be an error here?', error)
    );
  }

  /**
   * Handles when a notification is clicked on
   * @param notif Notification that was clicked
   */
  onNotifClick(notif: Notification) {
    // If notification hasn't been marked as read yet, let the server know it's been done
    if (!notif.readDate) {
      this.markNotifAsRead(notif);
    }

    // Try to navigate to the content linked within the notification
    this.router.navigate([notif.routeLink]); // TODO: At least SOME basic extra security!
  }

  /**
   * Marks all notifications for user as unread
   */
  markAllRead() {
    // Eagerly update all read dates for viewer on current page
    this.notifs.forEach(notifcation => {
      if (!notifcation.readDate) {
        notifcation.readDate = new Date();
      }
    });

    // Tell server that all notifications are now read
    this.notifService.markAllRead();
  }

  /**
   * Marks a single notification as read
   * @param notif Notification to mark as read
   */
  private markNotifAsRead(notif: Notification) {
    notif.readDate = new Date(); // Eagerly expect this call to work
    this.notifService.markSingleRead(notif.id);
  }

  private retrieveNotificationsPage(pageNumber) {
    this.isLoadingNotifications = true;

    this.currentPage = pageNumber; // Eager assumption
    this.notifService.getPage(pageNumber)
      .subscribe(
        response => {
          this.isLoadingNotifications = false;

          // Note: Assuming that even if there's a push notif before now, it will be accounted by server
          // This isn't a great assumption- can possibly get a notif assumed to be have been read but never seen
          this.notifs = response.notifications;
          this.totalNotifs = response.totalNotifications;
          this.currentPage = response.currentPage; // For robustness
        },
        error => {
          this.isLoadingNotifications = false;

          this.errorMsgs.push('Failed to get current notifications');
          console.log('Error getting current notifs: ', error);
        }
      );
  }

  /**
   * Sets up connection to get push notifications
   */
  private startPushNotifHub() {
    // Create an authorized connection
    this.connection = new HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/notify`, { accessTokenFactory: () => this.authService.getAccessToken() })
      .build();

    // Handle receiving notifications from server
    this.connection.on(NotificationsViewerComponent.BROADCAST_NAME,
    (notif: Notification) => {
      this.handlePushNotification(notif);
    });

    // Start the connection at the end to avoid any possible missed messages
    this.connection.start()
      .then(() => console.log('Connection started!'))
      .catch(err => {
        this.errorMsgs.push('Error while establishing connection')
        console.log('Error while establishing connection: ', err)
      });
    this.isLoadingPushService = false;
  }

  /**
   * Handles receiving a new push notification
   * @param notif New notification from push service
   */
  private handlePushNotification(notif: Notification) {
    // TODO Issue 29: Handle if not on first page (show at very top separately?)
    // If reached max page size, remove one to maintain a consistent display
    if (this.totalNotifs >= 20) {
      this.notifs.pop();
    }

    // As assuming push notif isn't in our list yet, this should be newest notif thus far
    this.notifs.unshift(notif);
    // Update total notifications count
    this.totalNotifs += 1;

    // Only do push notifications for important notifs
    if (notif.isImportant) {
      // TODO #30: Do actual client-level push notifications (eg, browser or phone notifs)

      this.showToastNotification(notif);
    }
  }
}