import { DashboardService } from './../../services/dashboard.service';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Post } from 'src/app/models/Post';
import { PostPopupComponent } from 'src/app/components/post-popup/post-popup.component';

@Component({
  selector: 'dash-posts-widget',
  templateUrl: './posts-widget.component.html',
  styleUrls: ['./posts-widget.component.css']
})
export class PostsWidgetComponent implements OnInit {
  @Input('type') type: string; // Currently only supporting 'General' and 'Character'
  
  @ViewChild('postPopup') postPopup: PostPopupComponent;

  posts: Post[];
  isLoading: boolean;
  header: string; // Title shown

  constructor(private dashService: DashboardService) { }

  ngOnInit() {
    this.isLoading = true;
    if(this.isTypeGeneral()) {
      this.header = "Popular General Posts";
      this.dashService.getPosts(-1, 0, -1).subscribe(postPage => 
        {
          this.isLoading = false;

          this.posts = postPage.posts;
        },
        error => this.postRetrievalError(error)
      );
    }
    else if(this.isTypeCharacter()) {
      this.header = "Latest Character Posts";
      this.dashService.getPosts(-1, -1, -1).subscribe(postPage => 
        {
          this.isLoading = false;

          this.posts = postPage.posts;
        },
        error => this.postRetrievalError(error)
      );
    }
    else {
      this.isLoading = false;
    }
  }

  postRetrievalError(error) {
    console.log("Failed to retrieve posts", error);
    this.isLoading = false;
  }

  open(post: Post) {
    this.postPopup.openPopup(post);
  }

  hasValidType(): boolean {
    return this.type && (this.isTypeGeneral() || this.isTypeCharacter());
  }

  isTypeGeneral(): boolean {
    return this.type === 'General';
  }

  isTypeCharacter(): boolean {
    return this.type === 'Character';
  }

}
