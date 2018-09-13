import { GameInfo } from './../../games/game-info.interface';
import { GameInfoService } from './../../games/game-info.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'game-switcher',
  templateUrl: './game-switcher.component.html',
  styleUrls: ['./game-switcher.component.css']
})
export class GameSwitcherComponent implements OnInit {
  games: GameInfo[];
  selectedGame: number;

  constructor(private gameInfoService: GameInfoService) { }

  ngOnInit() {
    // Get all games' basic info as well as currently selected game
    this.games = this.gameInfoService.getGames();
    this.selectedGame = this.gameInfoService.getCurrentGameId();
  }

  onGameChange() {
    // Notify everyone that the current game has been changed
    this.gameInfoService.setCurrentGame(this.selectedGame);
  }

}
