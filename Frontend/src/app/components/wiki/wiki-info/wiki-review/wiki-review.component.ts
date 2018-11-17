import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';

@Component({
  selector: 'app-wiki-review',
  templateUrl: './wiki-review.component.html',
  styleUrls: ['./wiki-review.component.css']
})
export class WikiReviewComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 1; // Default to Latest
  @Output('selectionChange') selectionChange = new EventEmitter<number>();
  
  sortOptions = PostInfo.PostSortOptions; // TODO: Put in a more centralized location
  
  constructor() { }

  ngOnInit() {
  }

}
