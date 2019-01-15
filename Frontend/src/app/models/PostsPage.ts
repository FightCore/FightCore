import { PostPreview } from './PostPreview';

export interface PostsPage {
    pageSize: number;
    pageNumber: number;
    total: number;
    posts: PostPreview[];
}
