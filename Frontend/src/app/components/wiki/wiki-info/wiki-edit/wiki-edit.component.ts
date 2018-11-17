import { PostMoveEvent } from './../../../post-edit-viewer/post-edit-viewer.component';
import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/Post';

export interface PostEditData {
  post: Post;

  isNew: boolean;
  shouldRemove: boolean;

  startingPos: number;
  currentPos: number;
  finalPos: number;
}

@Component({
  selector: 'app-wiki-edit',
  templateUrl: './wiki-edit.component.html',
  styleUrls: ['./wiki-edit.component.scss']
})
export class WikiEditComponent implements OnInit {
  data: Post[];
  
  constructor() { }

  ngOnInit() {
  }

  setData(postList: Post[]) {
    this.data = postList;
  }

  onMoveRequest(positions: PostMoveEvent) {
    WikiEditComponent.elementMove(this.data, positions.oldPos, positions.newPos);
  }

  onRemoveRequest(position: number) {
    console.log('Requested to remove element at position', position);
  }

  onAdd(atBeginning: boolean) {
    console.log('Add button clicked', atBeginning);
  }

  /**
   * Moves an element within an array
   * @param arr Array to modify
   * @param from Index of element to move
   * @param to Index of where element should
   */
  private static elementMove(arr: Array<any>, from: number, to: number) {
    if(from >= arr.length || from < 0 || to >= arr.length || to < 0) {
      throw new Error('elementMove: from and/or to is not in bounds');
    }

    if(from === to) { // Simple quick check, technically not necessary
      return;
    }

    arr.splice(to, 0, arr.splice(from,1)[0]); // Simple one liner move
  }

}
