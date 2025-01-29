import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private authService: AuthService, 
    private router: Router) {}

    ngOnInit(): void {
      this.loginForm = this.fb.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
      });
    }
  

  onLogin(): void{
    if (this.loginForm.invalid) return;

    const loginData = {
      username: this.loginForm.value.username,
      password: this.loginForm.value.password
    };

    this.http.post<any>('https://localhost:7023/api/auth/login', loginData)
      .subscribe(response => {
        // Handle success (e.g., save token, navigate to another page)
        localStorage.setItem('token', response.token);
        localStorage.setItem('user', loginData.username);

        this.authService.login();
        this.router.navigate(['/patients']);
      },
      error => {
        // Handle error
        alert('Invalid credentials');
      });
  }
}


// export class LoginComponent implements OnInit {
//   loginForm!: FormGroup;

//   constructor(
//     private fb: FormBuilder,
//     private http: HttpClient,
//     private router: Router
//   ) { }

//   ngOnInit(): void {
//     this.loginForm = this.fb.group({
//       username: ['', Validators.required],
//       password: ['', Validators.required]
//     });
//   }

//   onLogin(): void {
//     if (this.loginForm.invalid) return;

//     const loginData = {
//       username: this.loginForm.value.username,
//       password: this.loginForm.value.password
//     };

//     this.http.post<any>('https://localhost:7023/api/auth/login', loginData)
//       .subscribe(
//         response => {
//           // Handle success (e.g., save token, navigate to another page)
//           localStorage.setItem('token', response.token);
//           localStorage.setItem('user', JSON.stringify({ username: loginData.username }));

//           this.router.navigate(['/patients']);
//         },
//         error => {
//           // Handle error
//           alert('Invalid credentials');
//         }
//       );
//   }
// }
