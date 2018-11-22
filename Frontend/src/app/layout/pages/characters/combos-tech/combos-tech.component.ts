import { Component, OnInit, Input } from '@angular/core';
import { TabComponentInterface } from 'src/app/components/tabs/tab/tab-component.interface';

@Component({
  selector: 'characters-combos-tech',
  templateUrl: './combos-tech.component.html',
  styleUrls: ['./combos-tech.component.css']
})
export class CombosTechComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;
  
  constructor() { }

  ngOnInit() {
  }

}
