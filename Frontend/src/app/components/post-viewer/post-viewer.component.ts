import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/Post';

@Component({
  selector: 'post-viewer',
  templateUrl: './post-viewer.component.html',
  styleUrls: ['./post-viewer.component.css']
})
export class PostViewerComponent implements OnInit {
  @Input('displayPost') displayPost: Post;
  constructor() { }

  ngOnInit() {
  }

}
