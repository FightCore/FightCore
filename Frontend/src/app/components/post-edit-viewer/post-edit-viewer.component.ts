import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Post } from 'src/app/models/Post';

export interface PostMoveEvent {
  oldPos: number;
  newPos: number;
}

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
  @Input('isRemoved') isRemoved: boolean;

  // Context inputs used to determine what elements to display
  @Input('position') position: number; // Position of this post in list
  @Input('listLength') listLength: number; // Total length of post list

  @Output('move') moveEmitter = new EventEmitter<PostMoveEvent>(); // Emits target position wishes to move to
  @Output('remove') removeEmitter = new EventEmitter<number>(); // Emits position of element that should be removed
  @Output('undoRemove') undoRemoveEmitter = new EventEmitter<number>(); // Emits position of element that should be restored

  constructor() { }

  ngOnInit() {
  }

  onMoveLeft() {
    this.moveEmitter.emit({
      oldPos: this.position,
      newPos: this.position - 1
    });
  }

  onMoveRight() {
    this.moveEmitter.emit({
      oldPos: this.position,
      newPos: this.position + 1
    });
  }
  
  onRemove() {
    this.removeEmitter.emit(this.position);
  }

  onUndoRemove() {
    this.undoRemoveEmitter.emit(this.position);
  }

}
