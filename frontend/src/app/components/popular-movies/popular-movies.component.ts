import { Component } from '@angular/core';

@Component({
  selector: 'app-popular-movies',
  imports: [],
  templateUrl: './popular-movies.component.html',
  styleUrl: './popular-movies.component.scss'
})
export class PopularMoviesComponent {
  movies = [1, 2, 3, 4, 5];
}
