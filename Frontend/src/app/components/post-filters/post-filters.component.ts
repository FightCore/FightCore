import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';
import { MatSelect } from '@angular/material';

export interface PostFiltersStatus {
  categoryId: number;
  characterId: number;
}

@Component({
  selector: 'post-filters',
  templateUrl: './post-filters.component.html',
  styleUrls: ['./post-filters.component.scss']
})
export class PostFiltersComponent implements OnInit {
  @Input('initialCatSort') selectedPostCat: number = -1;
  @Output('selectionChange') selectionChange = new EventEmitter<PostFiltersStatus>();

  @ViewChild('catSelect') catSelect: MatSelect;

  postCatgories = PostInfo.PostCategories;

  constructor() { }

  ngOnInit() {
  }

  onSelectChange() {
    this.selectionChange.emit({
      categoryId: this.selectedPostCat,
      characterId: 0
    });
  }

  onClearCatSelect() {
    // Set to an invalid value
    this.selectedPostCat = -1;
    this.onSelectChange();
  }

}