import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { log } from 'console';
import { tap } from 'rxjs';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [CommonModule, FormsModule, RouterModule, HttpClientModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
})
export class Login {
  username = '';
  password = '';

  constructor(private http: HttpClient, private router:Router){}
     login(){
       const body = { username: this.username, password: this.password };
       console.log(body);
       
      this.http.post<any>("http://localhost:40080/api/login", {username: this.username, password: this.password })
      .subscribe({
      next: (res) => {
        console.log("Login Response:", res);
        localStorage.setItem("token", res.token); // ensure correct key
        this.router.navigate(['/cus']);
      },
      error: err => {
        console.log("Login Error:", err);
        alert("Invalid username or password");
      }
    });
     }

}
