import { Component, OnInit, Input } from '@angular/core';
import { ListChangeData } from '../list-change-data.interface';

@Component({
  selector: 'post-edit-viewer-changes',
  templateUrl: './post-edit-viewer-changes.component.html',
  styleUrls: ['./post-edit-viewer-changes.component.scss']
})
export class PostEditViewerChangesComponent implements OnInit {
  @Input('simpleMode') isSimpleMode: boolean;
  @Input('changeData') changeData: ListChangeData;
  
  constructor() { }

  ngOnInit() {
  }

  /**
   * Determines if the add section should show
   */
  showAddedSection(): boolean {
    return !this.isSimpleMode || this.changeData.added.length > 0;
  }

  /**
   * Determines if the removed section should show
   */
  showRemovedSection(): boolean {
    return !this.isSimpleMode || this.changeData.removed.length > 0;
  }

  /**
   * Determines if the reordered section should show
   */
  showReorderedSection(): boolean {
    // Show only when there seem to be no other changes
    return this.changeData.added.length === 0 && this.changeData.removed.length === 0;
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
