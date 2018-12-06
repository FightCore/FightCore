import { Component, OnInit, ViewChild } from '@angular/core';
import { PopupComponent } from '../popup/popup.component';
import { TabItem } from '../tabs/tab/tab-item';
import { PostEditConfirmContentsComponent } from './post-edit-confirm-contents/post-edit-confirm-contents.component';
import { ListChangeData } from '../post-edit-viewer/list-change-data.interface';

@Component({
  selector: 'post-edit-confirm',
  templateUrl: './post-edit-confirm.component.html',
  styleUrls: ['./post-edit-confirm.component.css']
})
export class PostEditConfirmComponent implements OnInit {
  @ViewChild('popup') popup: PopupComponent;

  constructor() { }

  ngOnInit() {
  }

  public show(changeData: ListChangeData): void {
    let postViewer = new TabItem(PostEditConfirmContentsComponent, changeData);
    this.popup.show(postViewer,"Confirm edit/suggestion");
  }

  onClose(): void {

  }

}
