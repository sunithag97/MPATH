// filepath: src/app/auth.service.ts
import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable({ providedIn: 'root' })

export class AuthService implements HttpInterceptor {
  private loggedIn = false;
  constructor() {}

  login() {

    this.loggedIn = true;
  }

  logout() {
    localStorage.removeItem('user');
    this.loggedIn = false;
  }

  isLoggedIn(): boolean {
    return this.loggedIn || localStorage.getItem('user') === 'true';
  }
  isAdmin(): boolean {
    const user = localStorage.getItem('user');
    if (user) 
      {
        return user === 'admin';
      }
    else {
      return false;
    }
  }


   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
      const token = localStorage.getItem('token');
      if (token) {
        req = req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`
          }
        });
      }
      return next.handle(req);
    }
}