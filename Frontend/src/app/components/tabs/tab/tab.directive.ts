import { Directive, Type, ViewContainerRef } from '@angular/core';

@Directive({selector: '[tab-host]'})
export class TabDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}
