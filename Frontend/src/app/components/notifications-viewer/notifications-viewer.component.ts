import { environment } from './../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'notifications-viewer',
  templateUrl: './notifications-viewer.component.html',
  styleUrls: ['./notifications-viewer.component.css']
})
export class NotificationsViewerComponent implements OnInit {
  msgs = [];

  constructor() { }

  ngOnInit() {
    let test = new HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/notify`)
      .build();
    
    test.start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection: ', err));

    test.on('BroadcastMessage', (type: string, payload: string) => {
      this.msgs.push({severity: type, summary: payload});
    })
  }

}
