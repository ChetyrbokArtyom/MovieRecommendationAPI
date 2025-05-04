import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../Services/auth.service'; 
import { UserService } from '../../Services/User.service'; 

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrls: ['../registration/registration.component.scss']
})
export class LoginComponent {
  user = {
    identifier: '',
    password: ''
  };

  showPassword: boolean = false;

  constructor(private router: Router, private authService: AuthService, private UserService: UserService) {}

  onSubmit(form: NgForm): void {
    if (!form.valid) {
      return;
    }

    this.authService.login(this.user).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token);
        const username = this.authService.getUsernameFromToken();
        this.UserService.setUsername(username); 
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('Ошибка входа:', err);
        alert(err.error?.error || 'Ошибка входа');
      }
    });
  }
}
