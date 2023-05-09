using AutoMapper;
using MovieApp.Data.DataModels;
using MovieApp.Domain.Commands.Movies;
using MovieApp.Domain.Models;

namespace MovieApp.Domain.Setup.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {
            CreateMovieMaps();
        }

        private void CreateMovieMaps()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, AddMovieCommand>();
            CreateMap<Movie, UpdateMovieCommand>();
            CreateMap<Movie, DeleteMovieCommand>();
            CreateMap<AddMovieCommand, MovieDto>();
            CreateMap<UpdateMovieCommand, MovieDto>();
            CreateMap<DeleteMovieCommand, MovieDto>();
        }
    }
}
