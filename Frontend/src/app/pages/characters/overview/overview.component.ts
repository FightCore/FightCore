import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { TabComponentInterface } from '../../../components/tabs/tab/tab-component.interface';
import { PostService } from '../../../services/post.service';
import { Post } from '../../../models/Post';
import { WikiPostsComponent } from 'src/app/components/wiki/wiki-posts/wiki-posts.component';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;

  @ViewChild('testPostList') testPostList: WikiPostsComponent;
  
  constructor(private postService: PostService) { }

  ngOnInit() {
    // Hacky testing of wiki post list
    // this.postListData = this.postService.getPosts().slice(0,2); // Get first two posts just for testing
    this.testPostList.nowLoadingPosts();
    this.postService.getPostsPage(5, 1, 0, -1).subscribe(
      posts => {
        this.testPostList.doneLoadingPosts(posts.posts);
      },
      error => {
        // TODO: Error handling/display

        this.testPostList.doneLoadingPosts([]);
      }
    );
  }

}
