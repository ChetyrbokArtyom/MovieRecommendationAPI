import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';
import { AuthService } from '../../Services/auth.service';
import { UserService } from '../../Services/User.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  searchQuery = '';
  searchResults: any[] = [];
  showAuthModal = false;
  profileMenuVisible = false;
  username: string | null = null;
  @ViewChild('authModal') authModal!: ElementRef;

  constructor(private http: HttpClient, private authService: AuthService, private router: Router, private UserService: UserService) {}
 
  ngOnInit(): void {
    this.UserService.username$.subscribe((username) => {
      this.username = username;
    });
  }

  updateUsername() {
    this.username = this.authService.getUsernameFromToken();
  }

  toggleAuthModal(): void {
    this.showAuthModal = !this.showAuthModal;
  }

  logout() {
    this.authService.logout(); // Добавь логику для выхода из системы
    this.username = null; // Очистить username
    this.profileMenuVisible = false; // Закрыть меню
    this.router.navigate(['/']);
  }

  closeAuthModal(): void {
    this.showAuthModal = false;
  }

  onSearch() {
    if (this.searchQuery.trim().length === 0) {
      this.searchResults = [];
      return;
    }

    const params = {
      Title: encodeURIComponent(this.searchQuery.trim()),
      page: 1,
      pageSize: 10
    };

    this.http.get('https://localhost:7253/api/movies/search', { params })
      .subscribe((response: any) => {
        this.searchResults = response;
      });
  }

  selectMovie(movie: any) {
    console.log('Selected movie:', movie);
    // Тут можно добавить переход по роуту или обработку
  }

  toggleProfileMenu() {
    this.profileMenuVisible = !this.profileMenuVisible;
  }

  @HostListener('document:click', ['$event'])
  handleClickOutside(event: MouseEvent) {
    if (
      this.showAuthModal &&
      this.authModal &&
      !this.authModal.nativeElement.contains(event.target)
    ) {
      this.showAuthModal = false;
    }
  }
  
}
