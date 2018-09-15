import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {

  constructor(private titleService: Title, private router: Router) { }

  ngOnInit() {
    this.titleService.setTitle("Library");
  }
  
  
  /**
   * Navigates to the add post page
   */
  goToAddPost() {
    this.router.navigate(['/library/add']);
  }

}
