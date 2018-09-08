import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { TabsInterface } from './tabs.interface';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.css']
})
export class TabsComponent implements OnInit {
  @Input('tabs') tabItems: TabsInterface[];   // Tabs to generate
  @Input('disableTabs') disableTabs: boolean; // If should disable applicable tabs

  constructor() { }

  ngOnInit() {
  }

}
