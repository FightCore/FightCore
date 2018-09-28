import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'post-sort',
  templateUrl: './post-sort.component.html',
  styleUrls: ['./post-sort.component.css']
})
export class PostSortComponent implements OnInit {
  @Input('selectedSort') selectedSort: number = 1; // Defaults to Popular

  sortOptions = [
    {
      id: 1,
      name: "Popular"
    },
    {
      id: 2,
      name: "Latest"
    },
    {
      id: 3,
      name: "Rating"
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}
