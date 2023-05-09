using AutoMapper;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Commands.Interfaces;

namespace MovieApp.Domain.Commands.Movies
{
    public class DeleteMovieHandler : ICommandHandler<DeleteMovieCommand>
    {
        private readonly IMovieRespository _movieRepository;
        public DeleteMovieHandler(IMovieRespository movieRespository)
        {
            _movieRepository = movieRespository;
        }

        public async Task Handle(DeleteMovieCommand movie)
        {
            try
            {
                await _movieRepository.Delete(movie.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
