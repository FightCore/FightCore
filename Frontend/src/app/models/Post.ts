export interface Post {
    id: number;
    authorId: number;
    createdDate: Date;
    lastEdit?: Date;
    views: number;
    rating?: number;
    urlName?: string;                // SEO purposes, part of url, based off of title

    // Meta fields
    category: number;
    characterIds?: number[];        // Required for all categories except Game-Independent
    // Combo specific fields
    targetCharacterIds?: number[];
    comboTypeIds?: number[];
    targetPercent?: number;         // TODO: Should be a range
    comboDmg?: number;
    comboStarterId?: number;

    // Additional fields
    skillLevel?: number;
    patchId?: number;

    // Content fields
    title: string;
    featuredLink?: string;
    content?: string;
}