import { TabItem } from './../components/tabs/tab/tab-item';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationsViewerComponent } from '../components/notifications-viewer/notifications-viewer.component';
import { PopupComponent } from '../components/popup/popup.component';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  @ViewChild('appPopup') popup: PopupComponent;

  constructor() {}

  ngOnInit() {
  }

  onNotifClick() {
    console.log('Layout component says onNotificationsClick');

    // TODO: Make the notification viewer component active in the background somehow
    // Want to be listening for push notifications without needing this open. Likely need to separate push service from UI and embed here
    let notifPopup = new TabItem(NotificationsViewerComponent, '');
    this.popup.show(notifPopup, 'Notifications');
  }
}
