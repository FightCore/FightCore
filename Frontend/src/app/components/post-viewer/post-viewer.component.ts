import { TabComponentInterface } from './../tabs/tab/tab-component.interface';
import { PostEditorComponent } from './../post-editor/post-editor.component';
import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../models/Post';

@Component({
  selector: 'post-viewer',
  templateUrl: './post-viewer.component.html',
  styleUrls: ['./post-viewer.component.css']
})
export class PostViewerComponent implements OnInit, TabComponentInterface {
  @Input('data') data: Post;
  @Input('simpleMode') simpleMode: boolean = false;
  
  constructor() { }

  ngOnInit() {
  }

  // TODO: Rewrite all the following to call into a more centralized location to get this info
  isCombo():boolean {
    return this.data.categoryId == PostEditorComponent.CombosCatId;
  }
  getCategoryName(): string {
    return this.data.categoryId + " (cat name)";
  }
  getAuthorName(): string {
    return this.data.authorId + " (name)";
  }
  getCharacterIcon(characterId: number): string {
    return characterId + " (icon)";
  }

}
