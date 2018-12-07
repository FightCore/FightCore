import { PostListService } from './../../../../services/post-list.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';
import { EditSuggestion } from 'src/app/models/EditSuggestion';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-wiki-review',
  templateUrl: './wiki-review.component.html',
  styleUrls: ['./wiki-review.component.css']
})
export class WikiReviewComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 1; // Default to Latest
  @Output('selectionChange') selectionChange = new EventEmitter<number>();
  
  suggestions: EditSuggestion[];
  isLoading: boolean;

  sortOptions = PostInfo.PostSortOptions; // TODO: Put in a more centralized location
  
  constructor(private postListService: PostListService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.isLoading = true;
    this.postListService.getPendingSuggestions(1).subscribe(
      list => {
        this.suggestions = list.suggestions;

        this.isLoading = false;
      },
      error => {
        this.snackBar.open('Sorry, could not retrieve list of current suggestions', 'Close', {
          duration: 2000
        });

        this.isLoading = false;
      }
    );
  }

}
