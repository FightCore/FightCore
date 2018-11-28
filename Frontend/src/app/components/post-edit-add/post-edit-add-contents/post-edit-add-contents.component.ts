import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { Post } from 'src/app/models/Post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'post-edit-add-contents',
  templateUrl: './post-edit-add-contents.component.html',
  styleUrls: ['./post-edit-add-contents.component.scss']
})
export class PostEditAddContentsComponent implements OnInit {
  @Output('done') done = new EventEmitter<Post>(); // For closing self in popup as necessary
  
  form: FormGroup;
  isLoading: boolean;

  lastSearch: string; // Stores previous search attempt for user feedback
  results: Post[]; // Results from previous search attempt

  constructor(fb: FormBuilder, private postService: PostService) {
    this.form = fb.group({
      searchControl: []
    });
   }

  ngOnInit() {
  }

  onSearch() {
    let searchControl = this.searchInputControl;
    this.lastSearch = searchControl.value; // For display purposes

    // Save some work if possible
    if(!searchControl.value) {
      return;
    }

    // If url, extract id from it
    let url: URL;
    try {
      url = new URL(searchControl.value);
    }
    catch {
      // Only expected error is that the url generation didn't work. No handling necessary
    }
    if(url) {
      // TODO: Check that the hostname is appropriate (for production environments at least)
      // Other checks shouldn't be necessary at all

      // Try extracting id. Should be <site>/library/<id>/<title>
      let splitPath = url.pathname.split('/');
      if(splitPath.length === 4) {
        let id: number = Number(splitPath[2]);
        if(!isNaN(id) && id > 0) {
          this.searchForId(id);
        }
        else {
          // Let the user know that the url seemed fine but id seemed invalid
          // TODO
        }
      }
      else {
        // Let the user know that the url was invalid
        // TODO
      }
      return; // No need to check other possibilities at this point
    }

    // If got to this point, converting to url failed so continue checking...

    // If just a number, assume it's the post id and search for it
    let numberAttempt: number = Number(searchControl.value);
    if(!isNaN(numberAttempt) && numberAttempt > 0) {
      this.searchForId(numberAttempt);
      return;
    }

    // Otherwise search across titles
    this.searchTitles(searchControl.value);
  }

  searchForId(postId: number) {
    console.log("searchForId", postId);

    // Show loading indicator
    this.isLoading = true;
    
    // Simply try to get post
    this.postService.getPost(postId).subscribe(
      post => this.displaySearchResults([post]),
      error => {
        // Placeholder until specific error handling
        console.log("Couldn't find post given id. Error: ", error);

        // Display no results found
        this.displaySearchResults(null);
      }
    );
  }

  searchTitles(text: string) {
    console.log("searchTitles", text);

    // Show loading indicator
    this.isLoading = true;
    
    // Try to search for posts
    this.postService.findPostsByTitle(text).subscribe(
      posts => this.displaySearchResults(posts),
      error => {
        // Placeholder until specific error handling
        console.log("Couldn't find post given search text. Error: ", error);

        // Display no results found
        this.displaySearchResults(null);
      }
    );
  }

  displaySearchResults(posts?: Post[]) {
    // If no results found... 
    if(!posts) {
      // Clear out display results and show that not loading
      this.results = [];
      this.isLoading = false;
    }
    else {
      // TODO: If a post is already added, display that and don't let user click on it

      // Simply display posts
      this.results = posts;
    }

    // Remove loading indicator
    this.isLoading = false;
  }

  selectPost(post: Post) {
    this.done.emit(post);
  }

  get searchInputControl(): AbstractControl { return this.form.get('searchControl'); }

}
