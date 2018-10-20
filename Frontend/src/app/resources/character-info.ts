import { SimpleInfo } from "./simple-info.interface";
import { ResourceBase } from "./resource-base";

export abstract class CharacterInfo {
    public static getCharacters(gameId: number): SimpleInfo[] {
        // TODO: Make these cases not hard coded
        switch(gameId) {
            case 1: // Smash 4
                return this.S4;
            default:
                return ResourceBase.NoneArray;
        }
    }

    public static getCharactersWithNone(gameId: number): SimpleInfo[] {
        return ResourceBase.createNoneArray(this.getCharacters(gameId));        
    }

    private static readonly S4: SimpleInfo[] = [
        { id: 0, name: "Bayonetta"},
        { id: 1, name: "Bowser"},
        { id: 2, name: "Bowser Jr."},
        { id: 3, name: "Captain Falcon"},
        { id: 4, name: "Charizard"}
    ];
}