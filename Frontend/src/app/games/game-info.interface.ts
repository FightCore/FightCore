export interface GameInfo {
    id: number,         // Id representing game on backend as well
    fullName: string,   // Full name of game
    shortName: string,  // Short name of game
    nameKey: string,    // Used for retrieving and storing files specifically for this game
}
