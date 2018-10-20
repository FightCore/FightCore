import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostInfo } from 'src/app/resources/post-info';

export interface PostFiltersStatus {
  categoryId: number;
  characterId: number;
}

@Component({
  selector: 'post-filters',
  templateUrl: './post-filters.component.html',
  styleUrls: ['./post-filters.component.css']
})
export class PostFiltersComponent implements OnInit {
  @Input('initialCatSort') selectedPostCat: number = -1;
  @Output('selectionChange') selectionChange = new EventEmitter<PostFiltersStatus>();

  postCatgories = PostInfo.getCategoriesWithNone();

  constructor() { }

  ngOnInit() {
  }

  onSelectChange() {
    this.selectionChange.emit({
      categoryId: this.selectedPostCat,
      characterId: 0
    });
  }

}
