import { WikiPermsComponent } from './wiki-perms/wiki-perms.component';
import { WikiHistoryComponent } from './wiki-history/wiki-history.component';
import { Component, OnInit } from '@angular/core';
import { TabsInterface } from '../../tabs/tabs.interface';
import { TabItem } from '../../tabs/tab/tab-item';
import { WikiReviewComponent } from './wiki-review/wiki-review.component';
import { WikiEditComponent } from './wiki-edit/wiki-edit.component';

@Component({
  selector: 'wiki-info',
  templateUrl: './wiki-info.component.html',
  styleUrls: ['./wiki-info.component.css']
})
export class WikiInfoComponent implements OnInit {
  tabItems: TabsInterface[];     // Tabs to generate

  constructor() { }

  ngOnInit() {
    // Initialize tabs
    this.tabItems = [
      {
        title: 'Review Edits',
        tabItem: new TabItem(WikiReviewComponent, '')
      },
      {
        title: 'Edit/Suggest',
        tabItem: new TabItem(WikiEditComponent, '')
      },
      {
        title: 'Full History',
        tabItem: new TabItem(WikiHistoryComponent, '')
      },
      {
        title: 'Permissions',
        tabItem: new TabItem(WikiPermsComponent, '')
      },

    ];
  }

}
