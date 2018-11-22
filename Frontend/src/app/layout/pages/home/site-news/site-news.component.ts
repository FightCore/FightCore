import { TabComponentInterface } from 'src/app/components/tabs/tab/tab-component.interface';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-site-news',
  templateUrl: './site-news.component.html',
  styleUrls: ['./site-news.component.scss']
})
export class SiteNewsComponent implements OnInit, TabComponentInterface {
  @Input('data') data: any;
  
  constructor() { }

  ngOnInit() {
  }

}
