import { Component, OnInit, Input } from '@angular/core';
import { TabComponentInterface } from '../../components/tabs/tab/tab-component.interface';

@Component({
  selector: 'dash-generator',
  templateUrl: './dash-generator.component.html',
  styleUrls: ['./dash-generator.component.scss']
})
export class DashGeneratorComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;

  constructor() { }

  ngOnInit() {
  }

}
