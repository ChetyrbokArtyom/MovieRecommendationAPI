import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private usernameSource = new BehaviorSubject<string | null>(null);
  username$ = this.usernameSource.asObservable();

  setUsername(username: string | null): void {
    this.usernameSource.next(username);
  }

  getUsername(): string | null {
    return this.usernameSource.value;
  }
}
