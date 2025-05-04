import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../Services/auth.service'; 


@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  user = {
    username: '',
    email: '',
    password: ''
  };

  confirmPassword: string = '';
  passwordError = '';
  emailError = '';
  showPassword: boolean = false;
  constructor(private router: Router, private authService: AuthService) {}

  onSubmit(form: NgForm): void {
    if (!form.valid || this.user.password !== this.confirmPassword) {
      return;
    }

    this.authService.register(this.user).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('Ошибка регистрации:', err);
        alert(err.error?.error || 'Ошибка регистрации');
      }
    });
  }
}