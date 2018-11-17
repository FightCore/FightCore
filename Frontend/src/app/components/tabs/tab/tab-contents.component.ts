import { Observable } from 'rxjs';
import { TabComponentInterface } from './tab-component.interface';
import { TabItem } from './tab-item';
import { Component, OnInit, Input, ViewChild, ComponentFactoryResolver, EventEmitter, Output } from '@angular/core';
import { TabDirective } from './tab.directive';

// TODO: Rewrite this entire folder to be less about tabs and more just about a modular section

@Component({
  selector: 'tab-contents',
  template: '<ng-template tab-host></ng-template>',
})
export class TabContentsComponent implements OnInit {
  @Input('tab') tab: TabItem;
  @Output('done') done = new EventEmitter(); // Generic pass-through output emitter

  @ViewChild(TabDirective) tabHost: TabDirective;

  constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit() {
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.tab.component);

    let viewContainerRef = this.tabHost.viewContainerRef;
    viewContainerRef.clear(); // Not sure if this line is necessary, ripping off of loading/reloading function

    let componentRef = viewContainerRef.createComponent(componentFactory);
    (<TabComponentInterface>componentRef.instance).data = this.tab.data;

    // Handle generic output emitter
    // TODO: Move this to a popup-specific implementation and make it better defined
    if(componentRef.instance.done && componentRef.instance.done instanceof EventEmitter) {
      componentRef.instance.done.subscribe(data => {
        this.done.emit(data); // Simply pass through the event
      })
    }
    // TODO: Move this to a popup-specific implementation, separate tab from popup?
    componentRef.instance.isPopupMode = true;

    // Let tab item itself know about the reference so parent can access the component
    this.tab.instantiatedComponent = componentRef.instance;
  }

}
