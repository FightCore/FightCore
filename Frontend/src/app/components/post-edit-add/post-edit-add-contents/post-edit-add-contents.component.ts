import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'post-edit-add-contents',
  templateUrl: './post-edit-add-contents.component.html',
  styleUrls: ['./post-edit-add-contents.component.css']
})
export class PostEditAddContentsComponent implements OnInit {
  @Output('done') done = new EventEmitter<number>(); // For closing self in popup as necessary
  
  constructor() { }

  ngOnInit() {
  }

  finished(pos: number) {
    this.done.emit(pos);
  }

}
