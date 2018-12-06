import { Post } from "src/app/models/Post";

export interface ListChangeData {
    added: Post[];
    removed: Post[];
    final: Post[];
}