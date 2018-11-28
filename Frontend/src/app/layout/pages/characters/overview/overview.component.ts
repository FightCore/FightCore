import { PostListService } from './../../../../services/post-list.service';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { TabComponentInterface } from 'src/app/components/tabs/tab/tab-component.interface';
import { WikiPostsComponent } from 'src/app/components/wiki/wiki-posts/wiki-posts.component';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;

  @ViewChild('testPostList') testPostList: WikiPostsComponent;
  
  constructor(private postListService: PostListService) { }

  ngOnInit() {
    // Hacky testing of wiki post list
    this.testPostList.nowLoadingPosts();

    this.postListService.getPostList(1).subscribe(
      postList => {
        this.testPostList.doneLoadingPosts(postList);
      },
      error => {
        // TODO: Error handling/display
        console.log('Failed to get test post list somehow', error);

        this.testPostList.doneLoadingPosts(null);
      }
    );
  }

}
