import { Component, OnInit, Input } from '@angular/core';
import { TabComponentInterface } from '../../../components/tabs/tab/tab-component.interface';

@Component({
  selector: 'characters-moves',
  templateUrl: './moves.component.html',
  styleUrls: ['./moves.component.css']
})
export class MovesComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;
  
  constructor() { }

  ngOnInit() {
  }

}
