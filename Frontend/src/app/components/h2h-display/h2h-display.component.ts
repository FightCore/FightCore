import { Component, OnInit } from '@angular/core';
import { Player } from '../../models/PlayerStats/Player';
import { StatisticList } from '../../models/PlayerStats/StatisticList';

@Component({
  selector: 'app-h2h-display',
  templateUrl: './h2h-display.component.html',
  styleUrls: ['./h2h-display.component.css']
})
export class H2hDisplayComponent implements OnInit {
  player1: Player;
  player2: Player;
  stageStats: StatisticList[] = [{statistic: 'Fountain of Dreams', player1Value: 5, player2Value: 10}];
  //stageStats = [new StatisticList("Fountain of Dreams", 5, 10)];
  columnsToDisplay: string[] = ['statistic', 'player1Value', 'player2Value'];

  constructor() {
    this.player1 = new Player("Hungrybox", "TL");
    this.player2 = new Player("Mew2king", "FOX");
   }

  ngOnInit() {
  }

}
