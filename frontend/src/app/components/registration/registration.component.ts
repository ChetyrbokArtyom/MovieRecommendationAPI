import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule, FormsModule], // Добавляем FormsModule
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  // Явно объявляем свойство user
  user = {
    username: '',
    email: '',
    password: ''
  };

  constructor(private router: Router) {}

  // Явно объявляем метод onSubmit
  onSubmit(): void {
    console.log('Регистрация:', this.user);
    // Здесь будет вызов сервиса для регистрации
    // После успешной регистрации:
    // this.router.navigate(['/']);
  }
}