import { GameInfo } from './../../games/game-info.interface';
import { GameInfoService } from './../../games/game-info.service';
import { Component, OnInit } from '@angular/core';
import { GameService } from './../../services/game.service';
import { Game } from '../../models/Game';

@Component({
  selector: 'game-switcher',
  templateUrl: './game-switcher.component.html',
  styleUrls: ['./game-switcher.component.css']
})
export class GameSwitcherComponent implements OnInit {
  games: Game[];
  selectedGame: number;

  constructor(private gameInfoService: GameInfoService, private gameService : GameService) { }

  ngOnInit() {
    // Get all games' basic info as well as currently selected game
    this.gameService.getAll().subscribe(response => this.games = response);
    this.selectedGame = this.gameInfoService.getCurrentGameId();
  }

  onGameChange() {
    // Notify everyone that the current game has been changed
    this.gameInfoService.setCurrentGame(this.selectedGame);
  }

}
