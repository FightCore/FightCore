import { SimpleInfo } from "./simple-info.interface";

export abstract class PostInfo {
    public static readonly CombosCatId = 1;
    public static readonly GameIndependentId = 5;
    public static readonly PostCategories: SimpleInfo[] = [
        { id: 0, name: 'General' },
        { id: 1, name: 'Combos' },
        { id: 2, name: 'Tech & Mechanics' },
        { id: 3, name: 'Counterplay' },
        { id: 4, name: 'Community' },
        { id: 5, name: 'Game Independent' }
    ];
    public static readonly PostSortOptions: SimpleInfo[] = [
        { id: 0, name: "Popular" },
        { id: 1, name: "Latest"  },
        { id: 2, name: "Rating"  }
    ];
    public static readonly PostSkillCategories: SimpleInfo[] = [
        { id: 1, name: 'N/A' },
        { id: 2, name: 'Beginner' },
        { id: 3, name: 'Intermediate' },
        { id: 2, name: 'Advanced' }
    ];
}