import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostService } from 'src/app/services/post.service';

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

  postCatgories = PostService.PostCategories;

  constructor() { }

  ngOnInit() {
    // Add None option to normal selections
    this.postCatgories.unshift({
      id: -1,
      name: 'None'
    });
  }

  onSelectChange() {
    this.selectionChange.emit({
      categoryId: this.selectedPostCat,
      characterId: 0
    });
  }

}
