import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/Post';

/**
 * Wrapper around a post preview to display edit capabilities
 */
@Component({
  selector: 'post-edit-viewer',
  templateUrl: './post-edit-viewer.component.html',
  styleUrls: ['./post-edit-viewer.component.scss']
})
export class PostEditViewerComponent implements OnInit {
  @Input('data') data: Post; // Post to display

  // Context inputs used to determine what elements to display
  @Input('position') position: number; // Position of this post in list
  @Input('listLength') listLength: number; // Total length of post list

  constructor() { }

  ngOnInit() {
  }

}
