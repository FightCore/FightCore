import { Component, OnInit, Input } from '@angular/core';
import { ListChangeData } from '../../post-edit-viewer/post-edit-viewer-changes/post-edit-viewer-changes.component';
import { Post } from 'src/app/models/Post';

@Component({
  selector: 'post-edit-confirm-contents',
  templateUrl: './post-edit-confirm-contents.component.html',
  styleUrls: ['./post-edit-confirm-contents.component.css']
})
export class PostEditConfirmContentsComponent implements OnInit {
  @Input('data') data: Post[]; // Final list of posts for previewing
  changeData: ListChangeData;

  constructor() { }

  ngOnInit() {
    // Testing
    this.changeData = {
      totalAdded: 0,
      totalRemoved: 0
    };
  }

}
