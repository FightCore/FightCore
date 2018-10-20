import { PostService } from './../../services/post.service';
import { TabComponentInterface } from './../tabs/tab/tab-component.interface';
import { PostEditorComponent } from './../post-editor/post-editor.component';
import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/Post';

@Component({
  selector: 'post-viewer',
  templateUrl: './post-viewer.component.html',
  styleUrls: ['./post-viewer.component.scss']
})
export class PostViewerComponent implements OnInit, TabComponentInterface {
  @Input('data') data: Post;
  @Input('simpleMode') simpleMode: boolean = false;
  
  isLoading: boolean;

  constructor(private postService: PostService) { }

  ngOnInit() {
    // If showing full post and don't have all data, then need to load that data
    if(!this.simpleMode && !this.data.createdDate) {
      this.isLoading = true;
      this.postService.getPost(this.data.id).subscribe(
        post => {
          this.isLoading = false;
          this.data = post;
        },
        error => {
          this.isLoading = false;
          console.log("Failed to get data", error);
        }
      );
    }
  }

  // TODO: Rewrite all the following to call into a more centralized location to get this info
  isCombo():boolean {
    return this.data.category == PostEditorComponent.CombosCatId;
  }
  getCategoryName(): string {
    return this.data.category + " (cat name)";
  }
  getAuthorName(): string {
    return this.data.authorId + " (name)";
  }
  getCharacterIcon(characterId: number): string {
    return characterId + " (icon)";
  }

}