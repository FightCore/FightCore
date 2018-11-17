import { EditSuggestion } from './../edit-suggestion.interface';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'edit-preview',
  templateUrl: './edit-preview.component.html',
  styleUrls: ['./edit-preview.component.scss']
})
export class EditPreviewComponent implements OnInit {
  @Input('data') data: EditSuggestion;

  constructor() { }

  ngOnInit() {
  }

  isNotPendingSuggestion(): boolean {
    // If any of these flags are set, then this is not a suggestion that still needs review (used to display history info)
    // TODO: Make this way cleaner (data structure)
    return this.data.isDirectEdit || this.data.isAccepted || this.data.isDenied;
  }

}
