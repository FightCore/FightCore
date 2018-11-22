import { Component, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { PostEditorComponent } from 'src/app/components/post-editor/post-editor.component';
import { PostService } from 'src/app/services/post.service';
import { Post } from 'src/app/models/Post';
import { PostSubmission } from 'src/app/models/PostSubmission';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  @ViewChild('postEditor') editor: PostEditorComponent;
  
  constructor(private titleService: Title,
    private router: Router,
    private postService: PostService) { }

  ngOnInit() {
    this.titleService.setTitle("Add Post");
  }

  onSubmitHandler(post: Post) {
    let newPost: PostSubmission = {
      category: post.category,
      title: post.title,
      content: post.content,
      featuredLink: post.featuredLink
    }

    this.postService.createPost(newPost)
    .subscribe(
      newPost => { 
        this.router.navigate(['/library']);

        // Just in case, let the post editor know things are done
        this.editor.onPostSubmit("");
      },
      error =>  { 
        this.editor.onPostSubmit(error);
      }
    );
  }

}
