import { WikiPermsComponent } from './wiki-perms/wiki-perms.component';
import { WikiHistoryComponent } from './wiki-history/wiki-history.component';
import { Component, OnInit, Input } from '@angular/core';
import { TabsInterface } from '../../tabs/tabs.interface';
import { TabItem } from '../../tabs/tab/tab-item';
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
  private readonly editComponentIndex = 1; // Index of edit component in tabItems

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
    this.initEditComponent();
  }

  initEditComponent() {
    // If component not yet initialized, wait until it is
    if(!this.tabItems[this.editComponentIndex].tabItem.instantiatedComponent) {
      // TODO: Do this in some fail safe way! eg, if doesn't work after X attempts, throw an error
      console.log("Edit component not yet instantiated, retrying later...");

      setTimeout(() => { this.initEditComponent() }, 100);
      return;
    }

    let editComponent = this.tabItems[this.editComponentIndex].tabItem.instantiatedComponent;
    if(editComponent instanceof WikiEditComponent) {
      editComponent.setData(this.currentPostList);
    }
    else {
      console.log('Error: editComponent not correct type', editComponent);
    }
  }

}
