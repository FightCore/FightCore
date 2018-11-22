import { PostsPage } from './../../models/PostsPage';
import { Post } from './../../models/Post';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { PostSubmission } from 'src/app/models/PostSubmission';
import { FakeUserService } from './fake-user.service';

export abstract class FakePostService {
    private static postList: Post[] = [
        {
            id: 1,
            authorId: 1,
            author: FakeUserService.getUser(1),
            createdDate: new Date(2018, 10, 12),
            lastEdit: new Date(2018, 10, 13),
            views: 0,
            rating: 22,
            urlName: '',
            category: 0,
            characterIds: [],
            title: 'Default Post A',
            content: 'Some test content, yay!'
        },
        {
            id: 2,
            authorId: 2,
            author: FakeUserService.getUser(2),
            createdDate: new Date(2018, 10, 13),
            lastEdit: new Date(2018, 10, 14),
            views: 0,
            rating: 2,
            urlName: '',
            category: 0,
            characterIds: [0],
            title: 'Default Post B',
            content: 'Some more test content, yay!'
        },
        {
            id: 3,
            authorId: 2,
            author: FakeUserService.getUser(2),
            createdDate: new Date(2018, 10, 14),
            lastEdit: new Date(2018, 10, 15),
            views: 0,
            rating: 42,
            urlName: '',
            category: 1,
            characterIds: [0],
            title: 'A Third Post, yay!',
            content: 'You know you wanted some more test content riiiiiiiight?'
        }
    ];

    public static getPost(id: number): Observable<Post> {
        return of(FakePostService.postList[id-1]).pipe(delay(500));
    }

    public static getPostsPage(): Observable<PostsPage> {
        let testPage: PostsPage = {
            pageSize: FakePostService.postList.length,
            pageNumber: 1,
            total: FakePostService.postList.length,
            posts: FakePostService.postList
        } 
        return of(testPage).pipe(delay(500));
    }

    public static createPost(newPost: PostSubmission): Observable<Post> {
        let post: Post = {
            id: FakePostService.postList.length + 1,
            authorId: FakePostService.postList[0].authorId,
            author:  FakePostService.postList[0].author,
            createdDate: new Date(),
            lastEdit: new Date(),
            views: 0,
            rating: 0,
            urlName: newPost.featuredLink,
            category: newPost.category,
            title: newPost.title,
            content: newPost.content
        };
        FakePostService.postList.push(post);

        return of(post).pipe(delay(500));
    }
}