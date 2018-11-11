import { Component, OnInit, HostListener } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  { path: '/home', title: 'Home',  icon:'home', class: '' },
  { path: '/characters', title: 'Characters',  icon:'copyright', class: '' },
  { path: '/library', title: 'Library',  icon:'book', class: '' },
  { path: '/players', title: 'Players',  icon:'person', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  innerWidth: number;

  constructor(private authService: OAuthService,  private router: Router) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.innerWidth = window.innerWidth;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.innerWidth = window.innerWidth;
  }

  isMobileMenu () {
    return this.innerWidth <= 991;
  }

  logOut() {
    this.authService.logOut(true);
    this.router.navigate(["/login"]);
  }

  get isLoggedIn(): boolean {
    return this.authService.hasValidAccessToken();
  }
}
