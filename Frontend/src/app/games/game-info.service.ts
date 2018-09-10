import { GameInfo } from './game-info.interface';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GameInfoService {
  private gamesInfo: GameInfo[] = [
    {
      id: 1,
      fullName: "Super Smash Bros. for Wii U",
      shortName: "Smash 4",
      nameKey: "s4"
    },
    {
      id: 2,
      fullName: "Super Smash Bros. Melee",
      shortName: "Melee",
      nameKey: "melee"
    },
    {
      id: 3,
      fullName: "Rivals of Aether",
      shortName: "RoA",
      nameKey: "roa"
    }
  ]
  private currentGameId: number = 1; // Default to Smash 4 for now

  constructor() { }

  /**
   * Gets all support games' basic info
   * @returns All games' basic info
   */
  public getGames(): GameInfo[] {    
    return this.gamesInfo;
  }

  /**
   * Get the currently selected game
   * @returns Game id as a number, -1 if no current game
   */
  public getCurrentGameId(): number {
    return this.currentGameId;
  }

  /**
   * Sets current game via corresponding game id
   * @param gameId Game id representing game to switch to
   */
  public setCurrentGame(gameId: number) {
    // TODO: If gameId not in current gamesInfo, then throw an error or at least return

    this.currentGameId = gameId;

    // TODO: Notify any subscribers for current game changes
  }

  // TODO: Some way to subscribe to game changes
}
