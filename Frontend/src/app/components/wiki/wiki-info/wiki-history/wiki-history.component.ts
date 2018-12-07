import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';
import { EditSuggestion } from 'src/app/models/EditSuggestion';

@Component({
  selector: 'app-wiki-history',
  templateUrl: './wiki-history.component.html',
  styleUrls: ['./wiki-history.component.css']
})
export class WikiHistoryComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 1; // Default to Latest
  @Output('selectionChange') selectionChange = new EventEmitter<number>();
  
  allChanges: EditSuggestion[];

  sortOptions = PostInfo.PostSortOptions; // TODO: Put in a more centralized location

  constructor() { }

  ngOnInit() {
    this.allChanges = [
      {
        author: 'TestUserA',
        createdDate: new Date(),
        commentCount: 0,
        rating: 1,

        description: 'Replaced old character guide with more comprehensive one',
        changes: {
          added: 1,
          removed: 1,
          reordered: 1
        },

        isAccepted: true,
        isDenied: false,
        isDirectEdit: false,

        reviewer: 'TestUserB',
        reviewDate: new Date()
      },
      {
        author: 'TestUserB',
        createdDate: new Date(),
        commentCount: 2,
        rating: 6,

        description: 'Added a B&B combo post',
        changes: {
          added: 1,
          removed: 0,
          reordered: 0
        },

        isAccepted: false,
        isDenied: false,
        isDirectEdit: true,

        reviewer: 'TestUserA',
        reviewDate: new Date()
      }
    ];
  }

}
