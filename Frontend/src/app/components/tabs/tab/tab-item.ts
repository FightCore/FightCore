import { Type } from '@angular/core';

export class TabItem {
  constructor(public component: Type<any>, public data: any) {}  
}

export interface TabInstantiation {
  type: Type<any>;
  instance: any;
}