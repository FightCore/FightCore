import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'post-sort',
  templateUrl: './post-sort.component.html',
  styleUrls: ['./post-sort.component.css']
})
export class PostSortComponent implements OnInit {
  @Input('initialSort') selectedSort: number = 0; // Defaults to Popular
  @Output('selectionChange') selectionChange = new EventEmitter<number>();

  sortOptions = PostService.PostSortOptions;

  constructor() { }

  ngOnInit() {
  }

  onSelectionChange() {
    this.selectionChange.emit(this.selectedSort);
  }

}
