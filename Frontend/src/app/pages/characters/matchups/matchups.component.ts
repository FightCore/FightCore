import { Component, OnInit, Input } from '@angular/core';
import { TabComponentInterface } from '../../../components/tabs/tab/tab-component.interface';

@Component({
  selector: 'characters-matchups',
  templateUrl: './matchups.component.html',
  styleUrls: ['./matchups.component.css']
})
export class MatchupsComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;
  
  constructor() { }

  ngOnInit() {
  }

}
