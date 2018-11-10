import { PostService } from './../../services/post.service';
import { TabComponentInterface } from './../tabs/tab/tab-component.interface';
import { Component, OnInit, Input, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { Post } from '../../models/Post';
import { PostInfo } from 'src/app/resources/post-info';
import { LinkEmbedComponent } from '../link-embed/link-embed.component';

@Component({
  selector: 'post-viewer',
  templateUrl: './post-viewer.component.html',
  styleUrls: ['./post-viewer.component.scss']
})
export class PostViewerComponent implements OnInit, TabComponentInterface {
  @Input('data') data: Post;
  @Input('simpleMode') simpleMode: boolean = false;
  
  @ViewChildren(LinkEmbedComponent) linkEmbedList: QueryList<LinkEmbedComponent>; // Can't just use ViewChild as dynamically generated
  linkEmbed: LinkEmbedComponent; // Should really only have one

  isLoading: boolean;

  constructor(private postService: PostService) { }

  ngOnInit() {
    // If showing full post...
    if(!this.simpleMode) {
      // If don't have full data, gotta get it first
      if(!this.data.lastEdit) {
        this.isLoading = true;
        this.postService.getPost(this.data.id).subscribe(
          post => {
            this.isLoading = false;
            this.data = post;

            this.showFeaturedLinkAsNecessary();
          },
          error => {
            this.isLoading = false;
            console.log("Failed to get data", error);
          }
        );
      }
      
    }
  }

  ngAfterViewInit() {
    // If full mode, retrieve the link embed component
    if(!this.simpleMode) {
      this.linkEmbedList.changes.subscribe(() => { 
        this.linkEmbed = this.linkEmbedList.first //  There should only be one
        setTimeout( () => this.showFeaturedLinkAsNecessary() );// Just in case data was already retrieved
      });
    }
  }

  /**
   * 
   */
  showFeaturedLinkAsNecessary() {
    // Start up embed component as necessary (has featured link, linkEmbed component has been retrieved, and is not yet showing)
    if(this.data.featuredLink && this.linkEmbed && !this.linkEmbed.isShowing) {
      let url = new URL(this.data.featuredLink);
      this.linkEmbed.show(url);
    }
  }

  // TODO: Rewrite all the following to call into a more centralized location to get this info
  isCombo():boolean {
    return this.data.category == PostInfo.CombosCatId;
  }
  getCategoryName(): string {
    return PostInfo.PostCategories[this.data.category].name;
  }
  getAuthorName(): string {
    return this.data.author.userName;
  }
  getCharacterIcon(): string {
    return 'assets/example_stock.png';
  }

}