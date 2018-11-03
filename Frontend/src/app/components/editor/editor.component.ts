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
    var toolbarOptions = [
      ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
      ['blockquote', 'code-block'],
    
      [{ 'header': 1 }, { 'header': 2 }],               // custom button values
      [{ 'list': 'ordered'}, { 'list': 'bullet' }],
      [{ 'script': 'sub'}, { 'script': 'super' }],      // superscript/subscript
      [{ 'indent': '-1'}, { 'indent': '+1' }],          // outdent/indent
    
      [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
      [ 'link', 'image', 'video', 'formula' ],          // add's image support
      [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
      [{ 'align': [] }],
    
      ['clean']                                         // remove formatting button
    ];
    let options = {
      placeholder: 'Change the world one post at a time...',
      theme: 'snow',
      modules: {
        toolbar: {
          container: toolbarOptions,
          handlers: {
            'image': () => { this.imageHandler(); } // Anonymous function in case called in different context
          }
        }
      }
    };
    this.editor = new Quill(this.container.nativeElement, options);
  }

  /**
   * Handles when the image button is clicked within the editor
   */
  imageHandler() {
    // Only allow embedding image urls for now
    var range = this.editor.getSelection();
    var value = prompt('What is the image URL?'); // Not great UI but works well for now without overdeveloping this
    this.editor.insertEmbed(range.index, 'image', value, 'user');
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
