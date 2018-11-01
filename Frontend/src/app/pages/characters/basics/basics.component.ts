import { Component, OnInit, Input } from '@angular/core';
import { TabComponentInterface } from '../../../components/tabs/tab/tab-component.interface';

@Component({
  selector: 'characters-basics',
  templateUrl: './basics.component.html',
  styleUrls: ['./basics.component.css']
})
export class BasicsComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;

  constructor() { }

  ngOnInit() {
  }

}
