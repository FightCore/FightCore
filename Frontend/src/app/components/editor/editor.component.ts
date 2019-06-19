import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { CovalentTextEditorModule, TdTextEditorComponent } from '@covalent/text-editor';
import { MarkdownService } from 'ngx-markdown';
import Quill from 'quill';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit {
  @ViewChild('textEditor') _textEditor: TdTextEditorComponent;
  @ViewChild('editorContainer') container: ElementRef;

  initText: string;
  markdownEditor: boolean;
  markdown: string;
  html: string;

  constructor(private markdownService: MarkdownService) {
  }

  options: any = {
    lineWrapping: true,
    toolbar: ['bold', 'italic', 'heading', '|', 'quote', 'side-by-side', 'fullscreen', 'preview'],
    spellChecker: false
  };

  ngOnInit() {
  }

  /**
   * Gets pure HTML contents from editor
   * @returns String containing formatted HTML
   */
  public getContents(): string {
    // Quill.getContents() returns "deltas" while getText() returns unformatted text
    // return this.editor.root.innerHTML;
    return this.markdown;
  }

  /**
   * Determines whether editor is empty or not
   * @returns true if empty
   */
  public isEmpty(): boolean {
    // return this.editor.getText() === '\n'; // Even if editor is empty, this contains a newline
    return false;
  }

  public setText(text: string) {
    this.markdown = text;
    this.html = this.markdownService.compile(text);
  }

  public isMarkdown(): boolean {
    return this.markdownEditor;
  }

  public toggleMarkdown() {
    if (this.markdownEditor) {
      this.setText(this._textEditor.value);
    }

    this.markdownEditor = !this.markdownEditor;

    if (this.markdownEditor) {
      setTimeout(() => { this._textEditor.writeValue(this.markdown); }, 100);
    }
  }

  editor(quill: Quill) {
    console.log('Quill ' + quill.getText());
  }
}
