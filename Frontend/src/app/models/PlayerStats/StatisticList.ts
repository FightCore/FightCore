export class StatisticList {
    statistic: string;
    player1Value: string | number;
    player2Value: string | number;   
    
    constructor(stat: string, value1: string | number, value2 : string | number) {
        this.statistic = stat;
        this.player1Value = value1;
        this.player2Value = value2;
    }
}