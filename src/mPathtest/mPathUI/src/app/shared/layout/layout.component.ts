// filepath: src/app/layout/layout.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent {
  constructor(private authService: AuthService, private router: Router) { }

  userName = localStorage.getItem('user');

  isSidenavOpened = true;

  toggleSidenav(): void {
    this.isSidenavOpened = !this.isSidenavOpened;
  }

  onLogout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
