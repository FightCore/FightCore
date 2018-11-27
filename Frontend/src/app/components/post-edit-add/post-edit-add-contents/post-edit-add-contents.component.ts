import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { Post } from 'src/app/models/Post';

@Component({
  selector: 'post-edit-add-contents',
  templateUrl: './post-edit-add-contents.component.html',
  styleUrls: ['./post-edit-add-contents.component.scss']
})
export class PostEditAddContentsComponent implements OnInit {
  @Output('done') done = new EventEmitter<number>(); // For closing self in popup as necessary
  
  form: FormGroup;
  isLoading: boolean;

  lastSearch: string; // Stores previous search attempt for user feedback
  results: Post[]; // Results from previous search attempt

  constructor(fb: FormBuilder) {
    this.form = fb.group({
      searchControl: []
    });
   }

  ngOnInit() {
  }

  onSearch() {
    let searchControl = this.searchInputControl;

    console.log('Search with text', searchControl.value);

    this.lastSearch = searchControl.value;
    this.isLoading = !this.isLoading;
  }

  finished(pos: number) {
    this.done.emit(pos);
  }

  get searchInputControl(): AbstractControl { return this.form.get('searchControl'); }

}
