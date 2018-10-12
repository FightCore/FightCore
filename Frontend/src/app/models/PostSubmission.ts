export interface IPostSubmission {
    id: number;
    author: {
        email: string,
        userName: string
    };
    authorId: number;
    content: string;
    featuredLink: string;
    title: string;
    createdDate: string;
    lastEdit: string;
    skillLevel: number;
    views: number;
    category: number;
    patchId: number;
}