import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import Quill from 'quill';

// NOTE: Quill doesn't currently support tables at all

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {
  @ViewChild('editorContainer') container: ElementRef;
  editor: Quill; // No good TS definition for Quill afaik

  constructor() { }

  ngOnInit() {
    let options = {
      placeholder: 'Change the world one post at a time...',
      theme: 'snow'
    };
    this.editor = new Quill(this.container.nativeElement, options);
  }

  /**
   * Gets pure HTML contents from editor
   * @returns String containing formatted HTML
   */
  public getContents(): string {
    // Quill.getContents() returns "deltas" while getText() returns unformatted text
    return this.editor.root.innerHTML;
  }

  /**
   * Determines whether editor is empty or not
   * @returns true if empty
   */
  public isEmpty(): boolean {
    return this.editor.getText() === '\n'; // Even if editor is empty, this contains a newline
  }

}
