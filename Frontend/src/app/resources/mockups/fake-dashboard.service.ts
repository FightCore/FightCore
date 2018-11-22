import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { PostsPage } from "src/app/models/PostsPage";
import { FakePostService } from './fake-post.service';

export abstract class FakeDashboardService {
    public static getPosts(sortId: number, category: number, characterId:  number, pageOrSpecialTypeInfo?: any): Observable<PostsPage> {
        let output: PostsPage = {
            pageSize: 0,
            pageNumber: 1,
            total: 0,
            posts: []
        }
        
        if(category === 0) { // "Popular General Posts"
            // Grab all the hardcoded General posts, in desc rating order
            output.posts = [FakePostService.postList[0], FakePostService.postList[1]];
            output.pageSize = 2;
            output.total = 2;
            return of(output).pipe(delay(500));
        }
        else { // "Latest <Character> Posts"
            // Grab all hardcoded posts with character ids in reverse date order
            output.posts = [FakePostService.postList[2], FakePostService.postList[1]];
            output.pageSize = 2;
            output.total = 2;
            return of(output).pipe(delay(500));
        }
    }
}