import { PostService } from './../../services/post.service';
import { TabComponentInterface } from './../tabs/tab/tab-component.interface';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Post } from '../../models/Post';
import { PostInfo } from 'src/app/resources/post-info';
import { EditorComponent } from '../editor/editor.component';
import { Category } from 'src/app/models/posts/Category';
import { OAuthService } from 'angular-oauth2-oidc';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'post-viewer',
  templateUrl: './post-viewer.component.html',
  styleUrls: ['./post-viewer.component.scss']
})
export class PostViewerComponent implements OnInit, TabComponentInterface {
  @Input('data') data: Post;
  @Input('simpleMode') simpleMode = false;
  @ViewChild('bodyEditor') bodyEditor: EditorComponent;

  isLoading: boolean;
  editing: boolean;

  constructor(private postService: PostService, private oauthService: OAuthService, private toastr: ToastrService) { }

  ngOnInit() {
    // If showing full post and don't have all data, then need to load that data
    if (!this.simpleMode && !this.data.createdDate) {
      this.isLoading = true;
      this.editing = false;
      this.postService.getPost(this.data.id).subscribe(
        post => {
          this.isLoading = false;
          this.data = post;
        },
        error => {
          this.isLoading = false;
          console.log('Failed to get data', error);
        }
      );
    }
  }

  // TODO: Rewrite all the following to call into a more centralized location to get this info
  isCombo(): boolean {
    return this.data.category === PostInfo.CombosCatId;
  }

  getCategoryName(): string {
    if (this.data.category != null) {
      return new Category().getCategoryById(this.data.category) + ' (category)';
    }

    return this.data.category + ' (cat name)';
  }

  getAuthorName(): string {
    if (!this.data.author) {
      return null;
    }
    return this.data.author.username;
  }

  getCharacterIcon(characterId: number): string {
    return characterId + ' (icon)';
  }

  isDeveloper(): boolean {
    return false;
  }

  isMyPost(): boolean {
    return this.data.authorId === this.getUserClaim();
  }

  getUserClaim(): number {
    const claims = this.oauthService.getIdentityClaims();
    if (!claims) {
      return null;
    }
    // Property is available, TypeScript not being a bro today.
    // @ts-ignore
    return parseFloat(`${claims.sub}`);
  }

  isEditing(): boolean {
    return this.editing;
  }

  toggleEditing(): void {
    // TODO look for user id.
    if (this.isMyPost()) {
      this.editing = !this.editing;

      // Set timeout cause the editor will be NULL otherwise.
      setTimeout(() => {
        this.bodyEditor.setText(this.data.content);
      }, 100);
    }

  }

  publishItem(): void {
    if (this.isMyPost()) {
      this.postService.publishPost(this.data.id, !this.data.published).subscribe(_ => {
        this.data.published = !this.data.published;
        let publishText = 'Changed post to be not published.';
        if (this.data.published) {
          publishText = 'Changed post to be published.';
        }
        this.toastr.success(publishText, 'Changed pulish status!');
      },
        error => {
          this.toastr.error('Error', 'Failed to change status');
        });
    }
  }

  upvotePost(): void {
    this.postService.upVotePost(this.data.id).subscribe(added => {
      if (added) {
        this.data.upvoteCount++;
        this.toastr.success('Upvoted post', 'Upvoted');
      } else {
        this.data.upvoteCount--;
        this.toastr.success('Removed upvote post', 'Upvoted');
      }
    });
  }
}
