export class Player {
    name: string;
    sponsor: string;

    constructor(name: string, sponsor: string = null) {
        this.name = name;
        this.sponsor = sponsor;
    }

    public toString = () : string => {
        if(this.sponsor) {
            return this.sponsor + " | " + this.name;
        }

        return this.name;
    }
}