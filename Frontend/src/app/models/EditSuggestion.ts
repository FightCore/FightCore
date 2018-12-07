export interface EditSuggestion {
    author: string;
    createdDate: Date;
    commentCount: number;
    rating: number;

    description: string;
    changes: PostEditChangeSummary;

    isAccepted: boolean;
    isDenied: boolean; // TODO: Only four states: Accepted, Denied, Direct Edit, Needs Review
    isDirectEdit: boolean;
    
    reviewer?: string;
    reviewDate?: Date;
}

export interface PostEditChangeSummary {
    added: number;
    removed: number;
    reordered: number;
}