import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var window: any;

@Component({
  selector: 'movie',
  templateUrl: './movie.component.html',
})

export class MovieComponent implements OnInit {
  public movies: Movie[] = [];
  public movieId: number = 0;
  public movieInfo: Movie[] = [];
  public movieExistsMessage = "A movie with this title already exists!";

  constructor(private http: HttpClient, @Inject('BASE_URL')public baseUrl: string) {
    this.http.get<Movie[]>(baseUrl + 'movie').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
    
  };

  addMovieModal: any;
  updateMovieModal: any;

  ngOnInit(): void {
    this.addMovieModal = new window.bootstrap.Modal(document.getElementById("addMovie"));
    this.updateMovieModal = new window.bootstrap.Modal(document.getElementById("updateMovie"));
  }

  addMovie() {
    this.addMovieModal.show();
  }

  saveMovie(@Inject('BASE_URL') baseUrl: string) {

    var movie = {
      title: (<HTMLInputElement>document.getElementById("movieTitle")).value,
      description: (<HTMLInputElement>document.getElementById("movieDesc")).value,
      rating: (<HTMLInputElement>document.getElementById("movieRating")).value,
      category: (<HTMLInputElement>document.getElementById("movieCategory")).value
    };

    this.http.post<number>(baseUrl + 'movie', movie).subscribe(result => {
      this.movieId = result;
      if (this.movieId == 0) {
        alert(this.movieExistsMessage);
      }
      this.addMovieModal.hide();
      this.clearForm();
      location.reload();
    }, error => console.error(error));
  }

  updateModalOpen(updateId: number, @Inject('BASE_URL') baseUrl: string) {
    
    this.http.get<Movie[]>(baseUrl + 'movie/' + updateId).subscribe(result => {
      this.movieInfo = result;
      (<HTMLInputElement>document.getElementById("updateId")).value = this.movieInfo[0].id.toString();
      (<HTMLInputElement>document.getElementById("updateTitle")).value = this.movieInfo[0].title.toString();
      (<HTMLInputElement>document.getElementById("updateDesc")).value = this.movieInfo[0].description.toString();
      (<HTMLInputElement>document.getElementById("updateRating")).value = this.movieInfo[0].rating.toString();
      (<HTMLInputElement>document.getElementById("updateCategory")).value = this.movieInfo[0].category.toString();
    }, error => console.error(error));

    this.updateMovieModal.show();
  }

  updateMovie(@Inject('BASE_URL') baseUrl: string) {

    var movie = {
      id: (<HTMLInputElement>document.getElementById("updateId")).value,
      title: (<HTMLInputElement>document.getElementById("updateTitle")).value,
      description: (<HTMLInputElement>document.getElementById("updateDesc")).value,
      rating: (<HTMLInputElement>document.getElementById("updateRating")).value,
      category: (<HTMLInputElement>document.getElementById("updateCategory")).value
    };

    this.http.put(baseUrl + 'movie', movie).subscribe(result => {
      this.updateMovieModal.hide();
      this.clearForm();
      location.reload();
    }, error => console.error(error));
    
  }

  deleteMovie(deleteId: number, @Inject('BASE_URL') baseUrl: string) {
    var movie = {
      id: deleteId,
      title: "string",
      category: "string",
      rating: 0,
      description: "string"
    };

    this.http.request('delete', baseUrl + 'movie', { body: movie }).
      subscribe(result => { location.reload() }, error => console.error(error));
    
  }

  closeNoSave() {
    this.addMovieModal.hide();
    this.updateMovieModal.hide();
    this.clearForm();
  }

  clearForm() {
    (<HTMLInputElement>document.getElementById("movieTitle")).value = '';
    (<HTMLInputElement>document.getElementById("movieDesc")).value = '';
    (<HTMLInputElement>document.getElementById("movieRating")).value = '';
    (<HTMLInputElement>document.getElementById("movieCategory")).value = '';

    (<HTMLInputElement>document.getElementById("updateId")).value = '';
    (<HTMLInputElement>document.getElementById("updateTitle")).value = '';
    (<HTMLInputElement>document.getElementById("updateDesc")).value = '';
    (<HTMLInputElement>document.getElementById("updateRating")).value = '';
    (<HTMLInputElement>document.getElementById("updateCategory")).value = '';
  }

}

interface Movie {
  id: number;
  title: string;
  description: string;
  category: string;
  rating: number;
}

