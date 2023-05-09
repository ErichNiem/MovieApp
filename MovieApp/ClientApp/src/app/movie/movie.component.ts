import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'movie',
  templateUrl: './movie.component.html',
})

export class MovieComponent {
  public movies: Movie[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movie[]>(baseUrl + 'movie').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

}

interface Movie {
  title: string;
  description: string;
  category: string;
  rating: number;
}
