import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
@Injectable({ providedIn: 'root' })
export class AuthService {
  private registerUrl = 'http://localhost:5144/api/user/Register';
  private loginUrl = 'http://localhost:5144/api/user/Login';

  constructor(private http: HttpClient) {}

 // Метод для выхода из системы
 logout(): void {
  // Очистка токенов из локального хранилища или куки
  localStorage.removeItem('authToken');
  sessionStorage.removeItem('authToken');
  // Вы можете добавить дополнительные очистки (например, куки)
}

  register(user: { username: string; email: string; password: string }) {
    const payload = {
      login: user.username,
      email: user.email,
      password: user.password
    };
    return this.http.post<{ token: string }>(this.registerUrl, payload);
  }

  login(user: { identifier: string; password: string }) {
    const payload = {
      identifier: user.identifier,
      password: user.password
    };
  
    return this.http.post<{ token: string }>(this.loginUrl, payload);
  }

  getUsernameFromToken(): string | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
  
    try {
      const decoded: any = jwtDecode(token);
      return decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    } catch (e) {
      return null;
    }
  }
  
}
