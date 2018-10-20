import { SimpleInfo } from "./simple-info.interface";

export abstract class ResourceBase {
    /**
     * Used to create simple quick array copies with None as the first option
     */
    public static readonly NoneArray: SimpleInfo[] = [
        { id: -1, name: "None" }
    ];

    /**
     * Concats None option in front of given array
     * @param base Base array to add None option in front of. Not changed
     * @returns Array of None option then base
     */
    public static createNoneArray(base: SimpleInfo[]): SimpleInfo[] {
        // No need to do a deep copy, just concat arrays
        //    Can't just do array.push or such as that acts on the same array object
        return ResourceBase.NoneArray.concat(base);
    }
}