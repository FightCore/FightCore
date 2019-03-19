import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { PostService } from 'src/app/services/post.service';
import { User } from 'src/app/models/User';
import { PostPreview } from 'src/app/models/PostPreview';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  username: string;
  posts: PostPreview[];
  loading = true;

  constructor(
    private titleService: Title,
    private authService: OAuthService,
    private router: Router,
    private postService: PostService) { }

  ngOnInit() {
    this.titleService.setTitle('Profile');

    this.authService.loadUserProfile().then(
      obj => {
        // Can't access Object's properties directly, being extra careful here
        const user = obj as User;
        if (user) {
          console.log(user);
          this.username = user.username;
          this.loadPosts(user.sub);
        } else {
          console.log('Object return is missing username!');
          this.username = '[Failed to get username]';
        }
      },
      reason => {
        this.username = '[Failed to get username]';
        console.log('Rejected: ', reason);
      }
    );
  }

  loadPosts(userId: number) {
    this.postService.getUserPosts(userId).subscribe(
      posts => {
         this.posts = posts as PostPreview[];
         this.loading = false;
      }
    )
  }
}