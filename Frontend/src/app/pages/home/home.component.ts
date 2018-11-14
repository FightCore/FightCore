import { environment } from './../../../environments/environment';
import { AboutUsComponent } from './about-us/about-us.component';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TabsInterface } from 'src/app/components/tabs/tabs.interface';
import { TabItem } from 'src/app/components/tabs/tab/tab-item';
import { SiteNewsComponent } from './site-news/site-news.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  tabItems: TabsInterface[];     // Tabs to generate
  
  constructor(private titleService: Title) { }

  ngOnInit() {
    if(environment.envName === 'noback') {
      this.titleService.setTitle('Home (No Backend Mode)');
    }
    else {
      this.titleService.setTitle('Home');
    }

    // Initialize tabs
    this.tabItems = [
      {
        title: 'Site News',
        tabItem: new TabItem(SiteNewsComponent, '')
      },
      {
        title: 'About Us',
        tabItem: new TabItem(AboutUsComponent, '')
      }
    ];
  }

}
