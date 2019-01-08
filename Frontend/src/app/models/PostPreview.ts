import { User } from './User';

export interface PostPreview {
    id: number;
    authorId: number;
    author?: User;
    title: string;
    category: number;
    views: number;

    //rating?: number;
    //characterIds?: number[];
}