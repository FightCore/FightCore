import { User } from "./User";

export interface PostPreview {
    id: number;
    authorId: number;
    author: User;
    createdDate: Date;
    title: string;
    category: number;
    views: number;
}