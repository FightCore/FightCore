export interface Post {
    id: number;
    urlName: string;                // SEO purposes, part of url, based off of title

    // Meta fields
    categoryId: number;
    characterIds?: number[];        // Required for all categories except Game-Independent
    // Combo specific fields
    targetCharacterIds?: number[];
    comboTypeIds?: number[];
    targetPercent?: number;         // TODO: Should be a range
    comboDmg?: number;
    comboStarterId?: number;

    // Additional fields
    skillEstimateId: number;
    patchId: number;
    tags: string[];

    // Content fields
    title: string;
    videoUrl?: string;
    textContent?: string;
}