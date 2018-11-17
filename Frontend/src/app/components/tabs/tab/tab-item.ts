import { Type, ComponentRef } from '@angular/core';

export class TabItem {
  public instantiatedComponent: any;

  constructor(public component: Type<any>, public data: any) {}  
}