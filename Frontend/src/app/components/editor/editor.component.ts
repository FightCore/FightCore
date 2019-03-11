import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { CovalentTextEditorModule, TdTextEditorComponent } from '@covalent/text-editor';


@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit, AfterViewInit {
  @ViewChild('textEditor') _textEditor: TdTextEditorComponent;
  @ViewChild('editorContainer') container: ElementRef;

  initText: string;
  markdownEditor: boolean;
  markdown: string;

  constructor() { }
  options: any = {
    lineWrapping: true,
    toolbar: ['bold', 'italic', 'heading', '|', 'quote', 'side-by-side', 'fullscreen', 'preview'],
    spellChecker: false
  };

  ngOnInit() {
  }

  ngAfterViewInit(): void {
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
    this._textEditor.writeValue(text);
  }

  public isMarkdown(): boolean {
    return this.markdownEditor;
  }

  public toggleMarkdown(button: any) {
    this.markdownEditor = !this.markdownEditor;
    if (this.markdownEditor) {
      button.text = 'Fancy Editor';
    } else {
      button.text = 'Markdown Editor';
    }
  }
}
