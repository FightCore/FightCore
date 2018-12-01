import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { H2hDisplayComponent } from '../../components/h2h-display/h2h-display.component';

@Component({
  selector: 'app-head-to-head',
  templateUrl: './head-to-head.component.html',
  styleUrls: ['./head-to-head.component.css']
})
export class HeadToHeadComponent implements OnInit {

  constructor(private titleService: Title) { }

  ngOnInit() {
    this.titleService.setTitle("Head to Head");
  }

}
