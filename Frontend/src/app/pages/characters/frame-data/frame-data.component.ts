import { Component, OnInit, Input } from '@angular/core';
import { TabComponentInterface } from '../../../components/tabs/tab/tab-component.interface';

@Component({
  selector: 'characters-frame-data',
  templateUrl: './frame-data.component.html',
  styleUrls: ['./frame-data.component.css']
})
export class FrameDataComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;
  
  constructor() { }

  ngOnInit() {
  }

}
