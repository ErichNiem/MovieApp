using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Queries.Interfaces;
using MovieApp.Domain.Commands.Movies;
using MovieApp.Domain.Models;
using MovieApp.Domain.Queries.Movies;

namespace MovieApp.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDipatcher;
        private readonly IMapper _mapper;
        public MovieController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IMapper mapper)
        {
            _commandDispatcher = commandDispatcher;
            _queryDipatcher = queryDispatcher;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            return await _queryDipatcher.Send<GetMultipleMoviesQuery, Movie>(new GetMultipleMoviesQuery { });
        }

        [HttpGet]
        [Route("/Movie/{id}")]
        public async Task<IEnumerable<Movie>> GetById(int id)
        {

            return await _queryDipatcher.Send<GetMovieQuery, Movie>(new GetMovieQuery { Id = id });
        }

        [HttpPost]
        public async Task Add(Movie movie)
        {
            var addMovie = _mapper.Map<Movie, AddMovieCommand>(movie);

            await _commandDispatcher.Send<AddMovieCommand, int>(addMovie);
        }

        [HttpPut]
        public async Task Update(Movie movie)
        {
            var updateMovie = _mapper.Map<Movie, UpdateMovieCommand>(movie);

            await _commandDispatcher.Send(updateMovie);
        }

        [HttpDelete]
        public async Task Delete(int movieId)
        {
            var deleteMovie = new DeleteMovieCommand { Id = movieId };

            await _commandDispatcher.Send(deleteMovie);
        }
    }
}
