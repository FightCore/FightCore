import { WikiPermsComponent } from './wiki-perms/wiki-perms.component';
import { WikiHistoryComponent } from './wiki-history/wiki-history.component';
import { Component, OnInit, Input } from '@angular/core';
import { TabsInterface } from '../../tabs/tabs.interface';
import { TabItem, TabInstantiation } from '../../tabs/tab/tab-item';
import { WikiReviewComponent } from './wiki-review/wiki-review.component';
import { WikiEditComponent } from './wiki-edit/wiki-edit.component';
import { Post } from 'src/app/models/Post';

@Component({
  selector: 'wiki-info',
  templateUrl: './wiki-info.component.html',
  styleUrls: ['./wiki-info.component.css']
})
export class WikiInfoComponent implements OnInit {
  private currentPostList: Post[]; // List to give to edit/suggest section

  tabItems: TabsInterface[]; // Tabs to generate
  editComponent: WikiEditComponent;

  constructor() { }

  ngOnInit() {
    // Initialize tabs
    this.tabItems = [
      {
        title: 'Review Suggestions',
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

  /**
   * Gives current post list which is then passed on to edit section
   * @param postList Current list of posts
   */
  setPostList(postList: Post[]) {
    // TODO: Handle loading in general
    // Eg if parent posts component is still loading, what should be shown all over in these areas?

    this.currentPostList = postList;

    // If edit component already around, pass this straight through
    if(this.editComponent) {
      this.initEditComponent();
    }
  }

  /**
   * Handle each tab being finally created
   * @param instanceData Tab instance that was created
   */
  onTabCreated(instanceData: TabInstantiation) {
    // We currently only care about the edit component
    if(instanceData.type === WikiEditComponent) {
      this.editComponent = instanceData.instance;

      // If data was already given, then pass it straight through
      if(this.currentPostList) {
        this.initEditComponent();
      }
    }
  }

  initEditComponent() {
    this.editComponent.initData(this.currentPostList);
  }

}
