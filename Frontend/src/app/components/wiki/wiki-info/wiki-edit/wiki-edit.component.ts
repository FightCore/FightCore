import { PostEditAddComponent } from './../../../post-edit-add/post-edit-add.component';
import { PostMoveEvent } from './../../../post-edit-viewer/post-edit-viewer.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Post } from 'src/app/models/Post';

export interface PostEditData {
  post: Post;

  startingPos: number;
  currentPos: number;
}

@Component({
  selector: 'app-wiki-edit',
  templateUrl: './wiki-edit.component.html',
  styleUrls: ['./wiki-edit.component.scss']
})
export class WikiEditComponent implements OnInit {
  @ViewChild('postAdder') postAdder: PostEditAddComponent;

  currentPosts: Post[];
  removedPosts: Post[];
  allPostData: PostEditData[];

  shouldAddBeginning: boolean;
  
  constructor() { }

  ngOnInit() {
  }

  setData(postList: Post[]) {
    // Make a copy of input as array itself is modified
    this.currentPosts = postList.map(post => ({...post}));

    // Generate metadata regarding all posts to track changes (shouldn't change post objects themselves)
    this.allPostData = [];
    postList.forEach((post, index) => {
      this.allPostData.push({
        post: post,
        startingPos: index,
        currentPos: index
      });
    });

    // Just in case, reset other post-based elements
    this.removedPosts = [];
  }

  onMoveRequest(positions: PostMoveEvent) {
    // Move the post visually for the user
    WikiEditComponent.elementMove(this.currentPosts, positions.oldPos, positions.newPos);

    // TODO: Update the tracking info for all posts whose positions were shifted?
    //        Better yet, why not limit this to post id + shift direction?
    //        This is what I get for doing data structures so early without proper planning
  }

  onRemoveRequest(position: number) {
    // Take the post out of the current posts area and keep a copy of it
    let removedPost: Post = this.currentPosts.splice(position, 1)[0];

    // Add the post to the removed section
    this.removedPosts.push(removedPost);

    // Note that no need to update current positioning info as it's not used here
  }

  undoRemove(position: number) {
    // Take this post out of the removed posts area and keep a copy of it
    let undoPost: Post = this.removedPosts.splice(position, 1)[0];

    // Get a reference to the post's metadata
    let metadata: PostEditData = this.allPostData.find(data => {
      return data.post.id === undoPost.id;
    }); 

    if(!metadata) {
      // All has gone wrong if this occurs
      throw new Error('Tried to undoRemove a post without metadata');
    }

    // Add the post to the current posts list at its original location
    this.currentPosts.splice(metadata.startingPos, 0, undoPost);
    metadata.currentPos = metadata.startingPos; // Will change object in overall array
  }

  onAdd(atBeginning: boolean) {
    this.shouldAddBeginning = atBeginning; // Update flag according to how add was chosen

    // Show add tool
    this.postAdder.show();
  }

  onAddChoice(postId: number) {
    console.log("onAddChoice: Add post", postId);

    // Double check that post isn't already in list

    // If post was removed earlier, clean up from removal list
  }

  /**
   * Moves an element within an array
   * @param arr Array to modify
   * @param from Index of element to move
   * @param to Index of where element should be
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
