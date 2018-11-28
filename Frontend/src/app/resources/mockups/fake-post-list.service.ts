import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { PostList } from 'src/app/models/PostList';
import { PostListPreview } from 'src/app/models/PostListPreview';
import { FakePostService } from './fake-post.service';

export abstract class FakePostListService {
  static postLists: PostListPreview[] = [
    {
      id: 1,
      postIds: [2]
    }
  ];

  private static fillPostListPreview(preview: PostListPreview): PostList {
    // Copy basic data
    let result: PostList = { id: preview.id, posts: []};

    // Find each post represented by ids
    preview.postIds.forEach(postId => {
      let post = FakePostService.fakeGetPostDirect(postId);
      if(post) { // Safety check
        result.posts.push(post);
      }
    });

    return result;
  }

  public static getPostList(listId: number): Observable<PostList> {
    let preview: PostListPreview = FakePostListService.postLists.find(list => list.id === listId);
    let result: PostList = FakePostListService.fillPostListPreview(preview);

    return of(result).pipe(delay(500));
  }
}