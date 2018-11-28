import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/Post';

export interface ListChangeData {
  totalAdded: number;
  totalRemoved: number;
}

@Component({
  selector: 'post-edit-viewer-changes',
  templateUrl: './post-edit-viewer-changes.component.html',
  styleUrls: ['./post-edit-viewer-changes.component.scss']
})
export class PostEditViewerChangesComponent implements OnInit {
  @Input('simpleMode') isSimpleMode: boolean;
  @Input('changeData') changeData: ListChangeData;
  
  @Input('finalList') finalList: Post[]; // Non-simple mode: Let user view what final list will look like

  constructor() { }

  ngOnInit() {
  }

  /**
   * Determines if the add section should show
   */
  showAddedSection(): boolean {
    return !this.isSimpleMode || this.changeData.totalAdded > 0;
  }

  /**
   * Determines if the removed section should show
   */
  showRemovedSection(): boolean {
    return !this.isSimpleMode || this.changeData.totalRemoved > 0;
  }

  /**
   * Determines if the reordered section should show
   */
  showReorderedSection(): boolean {
    // Show only when there seem to be no other changes
    return this.changeData.totalAdded === 0 && this.changeData.totalRemoved === 0;
  }

  /**
   * Determines whether or not to show first separator, after total added + total removed
   */
  showFirstSeparator(): boolean {
    return this.showAddedSection() && this.showRemovedSection();
  }

  /**
   * Determines if the second separator should show
   */
  showSecondSeperator(): boolean {
    // Show only if the reordered section isn't showing by itself (as it's last)
    return this.showReorderedSection() && (this.showAddedSection() || this.showRemovedSection());
  }

}
