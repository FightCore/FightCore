import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { PostList } from 'src/app/models/PostList';
import { PostListPreview } from 'src/app/models/PostListPreview';
import { FakePostService } from './fake-post.service';
import { EditSuggestion } from 'src/app/models/EditSuggestion';
import { SuggestionList } from 'src/app/models/SuggestionList';

export abstract class FakePostListService {
  static postLists: PostListPreview[] = [
    {
      id: 1,
      postIds: [2]
    }
  ];

  static suggestionLists: SuggestionList[] = [
    {
      id: 1,
      suggestions: [
        {
          author: 'TestUserA',
          createdDate: new Date(),
          commentCount: 0,
          rating: 1,

          description: 'Replaced old character guide with more comprehensive one',
          changes: {
            added: 1,
            removed: 1,
            reordered: 1
          },

          isAccepted: false,
          isDenied: false,
          isDirectEdit: false
        },
        {
          author: 'TestUserB',
          createdDate: new Date(),
          commentCount: 2,
          rating: 6,

          description: 'Added a B&B combo post',
          changes: {
            added: 1,
            removed: 0,
            reordered: 0
          },

          isAccepted: false,
          isDenied: false,
          isDirectEdit: false
        }
      ]
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

  public static getPendingSuggestions(listId: number): Observable<SuggestionList> {
    let result: SuggestionList = FakePostListService.suggestionLists.find(list => list.id === listId);
    return of(result).pipe(delay(500));
  }
}