import { Game } from './Game';

export interface Character {
    id: number;
    name: string;
    description: string;
    game: Game;
}