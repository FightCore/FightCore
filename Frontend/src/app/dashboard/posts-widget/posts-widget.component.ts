import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dash-posts-widget',
  templateUrl: './posts-widget.component.html',
  styleUrls: ['./posts-widget.component.css']
})
export class PostsWidgetComponent implements OnInit {
  @Input('type') type: string; // For mockup only supports 'General' and 'Character'

  constructor() { }

  ngOnInit() {
  }

  hasValidType(): boolean {
    return this.type && (this.isTypeGeneral() || this.isTypeCharacter());
  }

  isTypeGeneral(): boolean {
    return this.type === 'General';
  }

  isTypeCharacter(): boolean {
    return this.type === 'Character';
  }

}
