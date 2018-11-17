import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/Post';

@Component({
  selector: 'app-wiki-edit',
  templateUrl: './wiki-edit.component.html',
  styleUrls: ['./wiki-edit.component.css']
})
export class WikiEditComponent implements OnInit {
  data: Post[];
  
  constructor() { }

  ngOnInit() {
  }

  setData(postList: Post[]) {
    this.data = postList;
  }

}
