import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  searchQuery = '';  // строка для поиска
  searchResults: any[] = [];  // хранение результатов поиска
  showAuthModal = false;

  constructor(private http: HttpClient) {}

  toggleAuthModal(): void {
    this.showAuthModal = !this.showAuthModal;
  }

  closeAuthModal(): void {
    this.showAuthModal = false;
  }

  onSearch() {
    console.log('Searching for:', this.searchQuery);
    if (this.searchQuery.trim().length === 0) {
      this.searchResults = [];  // очищаем результаты, если строка поиска пустая
      return;
    }

    const params = {
      Title: encodeURIComponent(this.searchQuery.trim()),
      page: 1,
      pageSize: 10
    };

    this.http.get('https://localhost:7253/api/movies/search', { params })
      .subscribe((response: any) => {
        console.log(response);  // выводим ответ для отладки
        this.searchResults = response;  // сохраняем результаты поиска в переменную
      });
  }

  selectMovie(movie: any) {
    console.log('Selected movie:', movie);
    // Дополнительные действия при выборе фильма, например, переход на страницу фильма
  }
}
