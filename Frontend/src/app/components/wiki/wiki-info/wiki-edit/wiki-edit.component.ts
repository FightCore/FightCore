import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/Post';

@Component({
  selector: 'app-wiki-edit',
  templateUrl: './wiki-edit.component.html',
  styleUrls: ['./wiki-edit.component.css']
})
export class WikiEditComponent implements OnInit {
  postList: Post[];
  
  constructor() { }

  ngOnInit() {
  }

  setData(postList: Post[]) {
    this.postList = postList;
  }

}
