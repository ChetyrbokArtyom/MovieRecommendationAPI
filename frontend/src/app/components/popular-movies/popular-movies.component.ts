import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../Services/Movie.service';
import { CommonModule } from '@angular/common';
import { Movie } from '../../Services/Movie.model';

@Component({
  selector: 'app-popular-movies',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './popular-movies.component.html',
  styleUrls: ['./popular-movies.component.scss']
})
export class PopularMoviesComponent implements OnInit {
  movies: Movie[] = [];
  visibleMovies: Movie[] = [];
  currentIndex = 0;
  itemsToShow = 5;

  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies(): void {
    this.movieService.getPopularMovies().subscribe({
      next: (data) => {
        this.movies = data.Search || [];
        // Для бесконечного скролла дублируем начало в конец
        this.movies = [...this.movies, ...this.movies.slice(0, this.itemsToShow)];
        this.updateVisibleMovies();
      },
      error: (err) => console.error('Error:', err)
    });
  }

  nextSlide(): void {
    this.currentIndex = (this.currentIndex + 1) % (this.movies.length - this.itemsToShow + 1);
    this.updateVisibleMovies();
  }

  prevSlide(): void {
    this.currentIndex = (this.currentIndex - 1 + (this.movies.length - this.itemsToShow + 1)) % 
                       (this.movies.length - this.itemsToShow + 1);
    this.updateVisibleMovies();
  }

  private updateVisibleMovies(): void {
    const endIndex = this.currentIndex + this.itemsToShow;
    this.visibleMovies = this.movies.slice(this.currentIndex, endIndex);
    
    // Если достигли конца, добавляем начало для плавного перехода
    if (endIndex > this.movies.length) {
      this.visibleMovies = [
        ...this.visibleMovies,
        ...this.movies.slice(0, endIndex - this.movies.length)
      ];
    }
  }
}