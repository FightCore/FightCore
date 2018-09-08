import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { UserService } from '../services/user.service';
import { User } from '../models/User';
import { AppError } from '../errors/app-error';
import { NotFoundError } from '../errors/not-found-error';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private titleService: Title, private userService: UserService) { }

  ngOnInit() {
    this.titleService.setTitle("Profile");
    
    this.userService.getAll().subscribe((res: User[]) => {
      console.log(res)
    }, (error: AppError) => {
      // This won't trow this error this is just an example
      if (error instanceof NotFoundError)
        console.log('test')
    });
  }

}
