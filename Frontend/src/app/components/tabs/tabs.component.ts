import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TabsInterface } from './tabs.interface';
import { TabInstantiation } from './tab/tab-item';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.css']
})
export class TabsComponent implements OnInit {
  @Input('tabs') tabItems: TabsInterface[];   // Tabs to generate
  @Input('disableTabs') disableTabs: boolean; // If should disable applicable tabs
  @Output('instantiated') instantiated = new EventEmitter<TabInstantiation>();
  
  constructor() { }

  ngOnInit() {
  }

  /**
   * Pass through tab instance data from each individual content element
   * @param instanceData Tab instance that was created
   */
  onInstantiaton(instanceData: TabInstantiation) {
    this.instantiated.emit(instanceData);
  }

}
