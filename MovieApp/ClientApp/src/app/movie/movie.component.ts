import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var window: any;

@Component({
  selector: 'movie',
  templateUrl: './movie.component.html',
})

export class MovieComponent implements OnInit {
  public movies: Movie[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movie[]>(baseUrl + 'movie').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  };

  formModal: any;

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(document.getElementById("addMovie"));
  }

  addMovie() {
    this.formModal.show();
  }

  saveMovie() {
    this.formModal.hide();
  }

  closeNoSave() {
    this.formModal.hide();
  }

}

interface Movie {
  title: string;
  description: string;
  category: string;
  rating: number;
}
