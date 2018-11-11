import { Type } from '@angular/core';

export class TabItem {
  constructor(public component: Type<any>, public data: any) {}
}