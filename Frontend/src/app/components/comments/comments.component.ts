import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 1; // Default to Latest
  @Output('selectionChange') selectionChange = new EventEmitter<number>();
  
  sortOptions = PostInfo.PostSortOptions; // TODO: Put in a more centralized location

  constructor() { }

  ngOnInit() {
  }

  onSelectionChange() {
    // TODO
  }

  onPageChange(pageEvent: PageEvent) {
    // TODO
  }

}
