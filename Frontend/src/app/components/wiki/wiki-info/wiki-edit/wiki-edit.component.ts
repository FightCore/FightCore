import { MatSnackBar } from '@angular/material';
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
  anyChanges: boolean = true; // Represents if user has made any changes to this list
  
  constructor(private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  initData(postList: Post[]): void {
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

  onMoveRequest(positions: PostMoveEvent):void {
    // Move the post visually for the user
    WikiEditComponent.elementMove(this.currentPosts, positions.oldPos, positions.newPos);

    // TODO: Update the tracking info for all posts whose positions were shifted?
    //        Better yet, why not limit this to post id + shift direction?
    //        This is what I get for doing data structures so early without proper planning
  }

  /**
   * Handles trying to remove a post from the current posts list
   * @param position Position of post to remove from current posts list
   */
  onRemoveRequest(position: number): void {
    if(position < 0 || position >= this.currentPosts.length) {
      throw new Error('onRemoveRequest: Invalid position chosen: ' + position);
    }

    // Take the post out of the current posts area and keep a copy of it
    let removedPost: Post = this.currentPosts.splice(position, 1)[0];

    // If not a newly added post, add the post to the removed section
    if(!this.isPostNew(removedPost.id)) {
      this.removedPosts.push(removedPost);
    }

    // Note that no need to update current positioning info as it's not used here
  }

  /**
   * Un-remove a post from the post list
   * @param position Position of post to un-remove in removed posts area
   */
  undoRemove(position: number): void {
    if(position < 0 || position >= this.removedPosts.length) {
      throw new Error('undoRemove: Invalid position chosen: ' + position);
    }

    // Take this post out of the removed posts area and keep a copy of it
    let undoPost: Post = this.removedPosts.splice(position, 1)[0];

    // Get a reference to the post's metadata
    let metadata: PostEditData = this.getMetadata(undoPost.id);

    // Add the post to the current posts list at its original location
    this.currentPosts.splice(metadata.startingPos, 0, undoPost);
    metadata.currentPos = metadata.startingPos; // Will change object in overall array
  }

  /**
   * Handles clicking an add post button
   * @param atBeginning True if new post should be added at beginning of list, false if at end
   */
  onAdd(atBeginning: boolean): void {
    this.shouldAddBeginning = atBeginning; // Update flag according to how add was chosen

    // Show add tool
    this.postAdder.show();
  }

  onAddChoice(newPost: Post): void {
    console.log("onAddChoice: Add post", newPost);

    // Double check that post isn't already in list
    let copy: Post = this.currentPosts.find(post => { return post.id === newPost.id } );
    if(copy) {
      // Tell the user in some way that the post was already added
      this.snackBar.open('Sorry, that post has already been added to this list', 'Close', {
        duration: 2000
      });
      return;
    }

    // Add this post into the appropriate position
    let insertPos: number; // For updating metadata later
    if(this.shouldAddBeginning) {
      insertPos = 0;
      this.currentPosts.unshift(newPost);
    }
    else {
      insertPos = this.currentPosts.length;
      this.currentPosts.push(newPost);
    }

    // Loop over removal array and try to find a copy
    let index: number;
    copy = null; // For clarity
    for(index = 0; index < this.removedPosts.length; index++) { // For loop for index+break capability
      if(this.removedPosts[index].id === newPost.id) {
        copy = this.removedPosts[index];
        break;
      }
    }

    // If copy in removed posts found, clean it up
    let metadata: PostEditData;
    if(copy) {
      // Take out of removed list
      this.removedPosts.splice(index, 1);

      // Get the existing metadata and update current position
      metadata = this.getMetadata(newPost.id);
      metadata.currentPos = insertPos;
    }
    // Otherwise, if this was a completely new post, add new metadata
    else {
      metadata = {
        post: newPost,
        startingPos: -1,
        currentPos: insertPos
      };
      this.allPostData.push(metadata);
    }
  }

  /**
   * Determines whether post was newly added
   * @param postId Id of post to check
   * @returns True if post was newly added to list, false otherwise
   */
  isPostNew(postId: number): boolean {
    // TODO: Reorganize data structures so not doing an O(n) lookup per post just for this
    let metadata: PostEditData = this.getMetadata(postId);
    return metadata.startingPos === -1;
  }

  /**
   * Handles user clicking done button after making desired edits
   */
  onDoneEditing(): void {
    this.snackBar.open('Done with editing', 'Close', {duration: 2000});
  }

  private getMetadata(postId: number, isSafeCheck?: boolean): PostEditData {
    let metadata: PostEditData =  this.allPostData.find(data => {
      return data.post.id === postId;
    });

    if(!metadata && !isSafeCheck) {
      throw new Error('getMetadata: Could not find metadata for postId ' + postId);
    }

    return metadata;
  }

  private removeMetadata(postId: number): void {
    throw new Error('Not yet implemented');
  }

  /**
   * Does a full check to see if there are any applicable changes user made
   */
  private checkAnyChanges(): void {
    // TODO: If removal or add lists have any items, changes set for sure

    // TODO: Otherwise, check that current list does not match order of original list of posts

    throw new Error('Not yet implemented');
  }

  /**
   * Moves an element within an array
   * @param arr Array to modify
   * @param from Index of element to move
   * @param to Index of where element should be
   */
  private static elementMove(arr: Array<any>, from: number, to: number): void {
    if(from >= arr.length || from < 0 || to >= arr.length || to < 0) {
      throw new Error('elementMove: from and/or to is not in bounds');
    }

    if(from === to) { // Simple quick check, technically not necessary
      return;
    }

    arr.splice(to, 0, arr.splice(from,1)[0]); // Simple one liner move
  }

}
