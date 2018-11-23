import { GameJourneymenComponent } from './game-journeymen/game-journeymen.component';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TabsInterface } from 'src/app/components/tabs/tabs.interface';
import { TabItem } from 'src/app/components/tabs/tab/tab-item';
import { GameOverviewComponent } from './game-overview/game-overview.component';
import { GameBeginnerComponent } from './game-beginner/game-beginner.component';
import { GameIntermediateComponent } from './game-intermediate/game-intermediate.component';
import { GameAdvancedComponent } from './game-advanced/game-advanced.component';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  tabItems: TabsInterface[];     // Tabs to generate
  
  constructor(private titleService: Title) { }

  ngOnInit() {
    this.titleService.setTitle('Game');

    // Initialize tabs
    this.tabItems = [
      {
        title: 'Overview',
        tabItem: new TabItem(GameOverviewComponent, '')
      },
      {
        title: 'Beginner',
        tabItem: new TabItem(GameBeginnerComponent, '')
      },
      {
        title: 'Journeymen',
        tabItem: new TabItem(GameJourneymenComponent, '')
      },
      {
        title: 'Intermediate',
        tabItem: new TabItem(GameIntermediateComponent, '')
      },
      {
        title: 'Advanced',
        tabItem: new TabItem(GameAdvancedComponent, '')
      },
    ];
  }

}
