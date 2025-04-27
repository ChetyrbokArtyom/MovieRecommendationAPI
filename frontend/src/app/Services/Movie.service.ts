import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, forkJoin, of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { Movie, ApiResponse } from './Movie.model';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private apiUrl = 'https://www.omdbapi.com/';
  private apiKey = 'a7cfb312';

  private defaultMovieIds = [
    'tt0499549', // Аватар
    'tt1375666', // Начало
    'tt0816692', // Интерстеллар
    'tt0111161', // Побег из Шоушенка
    'tt0068646', // Крёстный отец
    'tt0137523', // Бойцовский клуб
    'tt0109830', // Форрест Гамп
    'tt0167260', // Властелин колец: Возвращение короля
    'tt0110357', // Король Лев
    'tt0120737'  // Властелин колец: Братство кольца
  ];

  constructor(private http: HttpClient) {}

  getPopularMovies(): Observable<{ Search: Movie[] }> {
    return this.http.get<ApiResponse>(`${this.apiUrl}?s=popular&apikey=${this.apiKey}`).pipe(
      catchError(() => this.fetchDefaultMovies()),
      map(response => {
        if (response.Search) {
          return { Search: response.Search.slice(0, 10) };
        }
        return { Search: [] };
      })
    );
  }

  private fetchDefaultMovies(): Observable<{ Search: Movie[] }> {
    const requests = this.defaultMovieIds.map(id => 
      this.http.get<Movie>(`${this.apiUrl}?i=${id}&apikey=${this.apiKey}`).pipe(
        catchError(() => of(null))
      )
    );

    return forkJoin(requests).pipe(
      map(movies => ({
        Search: movies
          .filter((movie): movie is Movie => movie !== null)
          .map(movie => ({
            Title: movie.Title || 'Неизвестный фильм',
            Poster: movie.Poster !== 'N/A' ? movie.Poster : 'https://via.placeholder.com/300x450?text=No+Poster',
            Year: movie.Year || 'Год не указан',
            imdbID: movie.imdbID || ''
          }))
      }))
    );
  }
}