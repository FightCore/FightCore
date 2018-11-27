import { TabItem } from './../tabs/tab/tab-item';
import { Component, OnInit, Input, EventEmitter, Output, ViewChild, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

/**
 * TODO:
 * What does this do
 * How to use it
 * BONUS: Can potentially rewrite to use only one popup, but that's for closer to the end once that's finalized
 */
@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html'
})
export class PopupComponent implements OnInit {
  @Output('onClose') onClose = new EventEmitter<any>();
  closeVal: any = null; // Explicitly null by default

  title: string;
  contentItem: TabItem; // TODO:  Rename interface and variable, plus document

  @ViewChild('container') popupContainer: TemplateRef<any>;

  constructor(private modalService: NgbModal) { }

  ngOnInit() {
  }

  /**
   * Opens a popup with the given contents
   * @param contents Defines what contents to display within 
   * @param [title] Title to display at the top of the popup
   */
  show(contents: TabItem, title?: string): void {
    this.contentItem = contents;
    this.title = title; // Should be safe even if null as checked in template
    
    this.modalService.open(this.popupContainer, 
      {
        windowClass: 'base-popup' // Defined in global styles.scss
      })
      .result.then((result) => {
        this.onClose.emit();
      }, (reason) => {
        this.onClose.emit(this.closeVal); // This part is also called during a coded dismiss like in onChildDone
        this.closeVal = null; // In case this popup component is reused
      }
    );
  }

  onChildDone(childVal: any) {
    if(childVal) {
      this.closeVal = childVal;
    }

    this.modalService.dismissAll();
  }

}
