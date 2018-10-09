import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Component, OnInit, ViewChild, TemplateRef, Output, EventEmitter } from '@angular/core';
import { Post } from '../../models/Post';

@Component({
  selector: 'post-popup',
  templateUrl: './post-popup.component.html',
  styleUrls: ['./post-popup.component.css']
})
export class PostPopupComponent implements OnInit {
  @Output('onClose') onClose = new EventEmitter<null>(); // For two way binding

  displayPost: Post;
  @ViewChild('postContent') postContent: TemplateRef<any>;

  constructor(private modalService: NgbModal) { }

  ngOnInit() {
  }

  public openPopup(post: Post) {
    this.displayPost = post;
    console.log("Called openPopup!");

    this.modalService.open(this.postContent, 
        {
          size: 'lg',
          windowClass: 'post-modal' 
        })
        // Change the url back once the post is closed
        .result.then((result) => {
          // This side isn't currently used (no save or such action for delegate), but here just in case
          this.onClose.emit(null);
        }, (reason) => {
          // This side is for dismissing the view popup (eg, clicking background or X/cross in corner)
          this.onClose.emit(null);
        });
  }

}
