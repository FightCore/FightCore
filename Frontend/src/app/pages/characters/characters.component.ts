import { CombosTechComponent } from './combos-tech/combos-tech.component';
import { BasicsComponent } from './basics/basics.component';
import { DashGeneratorComponent } from './../../dashboard/dash-generator/dash-generator.component';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TabItem } from '../../components/tabs/tab/tab-item';
import { TabsInterface } from '../../components/tabs/tabs.interface';
import { Character } from '../../models/Character';
import { MatchupsComponent } from './matchups/matchups.component';
import { FrameDataComponent } from './frame-data/frame-data.component';
import { OverviewComponent } from './overview/overview.component';

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrls: ['./characters.component.css']
})
export class CharactersComponent implements OnInit {
  tabItems: TabsInterface[];     // Tabs to generate
  tabsDisabled: boolean = true;  // Defines if tabs should be disabled. Will be used to disable tabs if no character selected
    
  constructor(private titleService: Title) { }

  ngOnInit() {
    this.titleService.setTitle("Characters");

    // Initialize tabs
    this.tabItems = [
      {
        title: "Overview",
        tabItem: new TabItem(OverviewComponent, {testData: "First tab data"})
      },
      {
        title: "Basics",
        tabItem: new TabItem(BasicsComponent, {testData: "Second tab data"}),
        canDisable: true
      },
      {
        title: "Frame Data",
        tabItem: new TabItem(FrameDataComponent, {testData: "Third tab data"}),
        canDisable: true
      },
      {
        title: "Combos & Tech",
        tabItem: new TabItem(CombosTechComponent, {testData: "Fourth tab data"}),
        canDisable: true
      },
      {
        title: "Matchups",
        tabItem: new TabItem(MatchupsComponent, {testData: "Fifth tab data"}),
        canDisable: true
      }
    ];
  }

  
  /**
   * Handles updating the overall page when user changes the character selected
   * @param character Selected character
   */
  charChangeHandler(character?: Character) {
    // For now, simply disable additional tabs if None is selected and otherwise enable the tabs
    if(!character) {
      this.tabsDisabled = true;
    }
    else {
      this.tabsDisabled = false;
    }
  }

}
