import { PostEditConfirmComponent } from './../../../post-edit-confirm/post-edit-confirm.component';
import { MatSnackBar } from '@angular/material';
import { PostEditAddComponent } from './../../../post-edit-add/post-edit-add.component';
import { PostMoveEvent } from './../../../post-edit-viewer/post-edit-viewer.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Post } from 'src/app/models/Post';
import { ListChangeData } from 'src/app/components/post-edit-viewer/list-change-data.interface';

@Component({
  selector: 'app-wiki-edit',
  templateUrl: './wiki-edit.component.html',
  styleUrls: ['./wiki-edit.component.scss']
})
export class WikiEditComponent implements OnInit {
  @ViewChild('postAdder') postAdder: PostEditAddComponent;
  @ViewChild('postConfirmer') postConfirmer: PostEditConfirmComponent;

  originalPosts: Post[]; // Reference for comparing

  changeData: ListChangeData;

  shouldAddBeginning: boolean;
  haveAnyChanges: boolean; // Represents if user has made any changes to this list
  
  constructor(private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  initData(postList: Post[]): void {
    this.changeData = {
      added: [],
      removed: [],
      final: []
    }

    this.originalPosts = postList; // For checking if there are any reorder modifications
    // Make a copy of input as array itself is modified
    this.changeData.final = postList.map(post => ({...post}));

    // Just in case, reset other post-based elements
    this.haveAnyChanges = false;
  }

  onMoveRequest(positions: PostMoveEvent):void {
    // If positions are out of bounds...
    if(positions.oldPos >= this.changeData.final.length || positions.oldPos < 0 || 
      positions.newPos >= this.changeData.final.length || positions.newPos < 0) {
      // Give user feedback then back out
      this.snackBar.open('Sorry, that move request is invalid... although that shouldn\'t be possible', 'Close', {
        duration: 2000
      });
      return;
    }

    // Move the post for the user
    WikiEditComponent.elementMove(this.changeData.final, positions.oldPos, positions.newPos);

    // Can't be sure actually have any changes compared to original list so double check
    this.checkAnyChanges();
  }

  /**
   * Handles trying to remove a post from the current posts list
   * @param position Position of post to remove from current posts list
   */
  onRemoveRequest(position: number): void {
    if(position < 0 || position >= this.changeData.final.length) {
      // Give user feedback then back out
      this.snackBar.open('Sorry, that remove position is invalid... although that shouldn\'t be possible', 'Close', {
        duration: 2000
      });
      return;
    }

    // Take the post out of the current posts area and keep a copy of it
    let removedPost: Post = this.changeData.final.splice(position, 1)[0];

    // If a newly added post, remove it without a trace- user changed their mind
    let newPostPos = this.getNewPostPos(removedPost.id);
    if(newPostPos > -1) {
      this.changeData.added.splice(newPostPos, 1);

      this.checkAnyChanges(); // Need to double check as not sure at this point
    }
    // Otherwise, keep track of this pre-existing post for tracking and letting the user easily reverse decision
    else {
      this.changeData.removed.push(removedPost);

      this.haveAnyChanges = true; // For sure have new changes so just set
    }
  }

  /**
   * Un-remove a post from the post list
   * @param position Position of post to un-remove in removed posts area
   */
  undoRemove(position: number): void {
    if(position < 0 || position >= this.changeData.removed.length) {
      // Give user feedback then back out
      this.snackBar.open('Sorry, that undo position is invalid... although that shouldn\'t be possible', 'Close', {
        duration: 2000
      });
      return;
    }

    // Take this post out of the removed posts area and keep a copy of it
    let undoPost: Post = this.changeData.removed.splice(position, 1)[0];

    // Find original position of this post for easy reinsertion
    let originalPos = -1;
    for(let i = 0; i < this.originalPosts.length; i++) {
      if(this.originalPosts[i].id === undoPost.id) {
        originalPos = i;
        break;
      }
    }
    if(originalPos === -1) { // Really should not happen
      throw new Error('undoRemove: Could not find post in original list')
    }

    // Add the post to the current posts list at its original location
    this.changeData.final.splice(originalPos, 0, undoPost);

    this.checkAnyChanges(); // May or may not have changes compared to original list anymore
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
    // Double check that post isn't already in list
    let copy: Post = this.changeData.final.find(post => { return post.id === newPost.id } );
    if(copy) {
      // Tell the user in some way that the post was already added
      this.snackBar.open('Sorry, that post has already been added to this list', 'Close', {
        duration: 2000
      });
      return;
    }

    // Add this post into the appropriate position
    if(this.shouldAddBeginning) {
      this.changeData.final.unshift(newPost);
    }
    else {
      this.changeData.final.push(newPost);
    }

    // Loop over removal array and try to find a copy to remove it
    let index: number;
    copy = null; // For clarity
    for(index = 0; index < this.changeData.removed.length; index++) { // For loop for index+break capability
      if(this.changeData.removed[index].id === newPost.id) {
        copy = this.changeData.removed[index];
        break;
      }
    }

    // If copy in removed posts found, clean it up
    if(copy) {
      this.changeData.removed.splice(index, 1);

      this.checkAnyChanges(); // User may have just gone on a roundabout way to undo their changes
    }
    // Otherwise, if this was a completely new post, keep track of it
    else {
      this.changeData.added.push(newPost);

      this.haveAnyChanges = true; // Definitely have changes at this point
    }
  }

  /**
   * Handles user clicking done button after making desired edits
   */
  onDoneEditing(): void {
    this.postConfirmer.show(this.changeData);
  }

  /**
   * Checks if a post is completely new to this list
   * @param postId Id of post to check
   * @returns True if post is completely new, false otherwise
   */
  isPostNew(postId: number): boolean {
    // This post is new if it exists in the new posts array
    this.changeData.added.forEach(post => {
      if(post.id === postId) {
        return true;
      }
    });

    // Otherwise, this post is definitely not completely new to the list
    return false;
  }

  /**
   * Gets position of new post in new post array
   * @param postId Id of post to check
   * @returns Id of position of new post in appropriate array, or -1 if not found
   */
  private getNewPostPos(postId: number): number {
    // Simply linear search
    let matchPos = -1;
    for(let i = 0; i < this.changeData.added.length; i++) {
      if(this.changeData.added[i].id === postId) {
        matchPos = i;
        break;
      }
    }
    return matchPos;
  }

  /**
   * Does a full check to see if there are any applicable changes user made
   */
  private checkAnyChanges(): void {
    // TODO: If removal or add lists have any items, changes set for sure
    if(this.changeData.removed.length > 0 || this.changeData.added.length > 0) {
      this.haveAnyChanges = true;
      return;
    }

    // Sanity check- with no removes or new adds, the two lists should be equal size
    if(this.originalPosts.length !== this.changeData.final.length) {
      throw new Error('checkAnyChanges: originalPosts and changeData.final MUST be same length at this point!');
    }

    // Otherwise, check that current list does not match order of original list of posts
    for(let i = 0; i < this.originalPosts.length; i++) {
      // If same exact post isn't in a position, then posts are different
      if(this.originalPosts[i].id !== this.changeData.final[i].id) {
        this.haveAnyChanges = true;
        return;
      }
    }

    // Otherwise, there really aren't any changes
    this.haveAnyChanges = false;
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
