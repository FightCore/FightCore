import { CombosTechComponent } from './combos-tech/combos-tech.component';
import { MovesComponent } from './moves/moves.component';
import { BasicsComponent } from './basics/basics.component';
import { DashGeneratorComponent } from './../../dashboard/dash-generator/dash-generator.component';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TabItem } from '../../components/tabs/tab/tab-item';
import { TabExampleComponent } from '../../components/tabs/tab-example/tab-example.component';
import { TabsInterface } from '../../components/tabs/tabs.interface';
import { Character } from '../../models/Character';
import { MatchupsComponent } from './matchups/matchups.component';

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
        title: "Dashboard",
        tabItem: new TabItem(DashGeneratorComponent, {testData: "First tab data"})
      },
      {
        title: "Basics",
        tabItem: new TabItem(BasicsComponent, {testData: "Second tab data"}),
        canDisable: true
      },
      {
        title: "Moves",
        tabItem: new TabItem(MovesComponent, {testData: "Third tab data"}),
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
  charChangeHandler(character: Character) {
    // For now, simply disable additional tabs if None is selected and otherwise enable the tabs
    if(character.id === 0) { // 0 is always None
      this.tabsDisabled = true;
    }
    else {
      this.tabsDisabled = false;
    }
  }

}
