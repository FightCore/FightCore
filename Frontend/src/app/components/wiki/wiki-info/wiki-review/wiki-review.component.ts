import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';
import { EditSuggestion } from '../../edit-suggestion.interface';

@Component({
  selector: 'app-wiki-review',
  templateUrl: './wiki-review.component.html',
  styleUrls: ['./wiki-review.component.css']
})
export class WikiReviewComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 1; // Default to Latest
  @Output('selectionChange') selectionChange = new EventEmitter<number>();
  
  suggestions: EditSuggestion[];

  sortOptions = PostInfo.PostSortOptions; // TODO: Put in a more centralized location
  
  constructor() { }

  ngOnInit() {
    this.suggestions = [
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

        isAccepted: false,
        isDenied: false,
        isDirectEdit: false
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
        isDirectEdit: false
      }
    ];
  }

}
