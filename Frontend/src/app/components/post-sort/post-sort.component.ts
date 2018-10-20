import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';

@Component({
  selector: 'post-sort',
  templateUrl: './post-sort.component.html',
  styleUrls: ['./post-sort.component.css']
})
export class PostSortComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 0; // Defaults to Popular
  @Output('selectionChange') selectionChange = new EventEmitter<number>();

  sortOptions = PostInfo.PostSortOptions;

  constructor() { }

  ngOnInit() {
  }

  onSelectionChange() {
    this.selectionChange.emit(this.selectedSort);
  }

}
