import { TabComponentInterface } from './tab-component.interface';
import { TabItem } from './tab-item';
import { Component, OnInit, Input, ViewChild, ComponentFactoryResolver } from '@angular/core';
import { TabDirective } from './tab.directive';

@Component({
  selector: 'tab-contents',
  template: '<ng-template tab-host></ng-template>',
})
export class TabContentsComponent implements OnInit {
  @Input('tab') tab: TabItem;
  @ViewChild(TabDirective) tabHost: TabDirective;

  constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit() {
    console.log(this.tab);
    console.log(this.tabHost);
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.tab.component);

    let viewContainerRef = this.tabHost.viewContainerRef;
    viewContainerRef.clear(); // Not sure if this line is necessary, ripping off of loading/reloading function

    let componentRef = viewContainerRef.createComponent(componentFactory);
    (<TabComponentInterface>componentRef.instance).data = this.tab.data;
  }

}
