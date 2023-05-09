using AutoMapper;
using MovieApp.Data.DataModels;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Commands.Interfaces;

namespace MovieApp.Domain.Commands.Movies
{
    public class UpdateMovieHandler : ICommandHandler<UpdateMovieCommand>
    {
        private readonly IMovieRespository _movieRepository;
        private readonly IMapper _mapper;
        public UpdateMovieHandler(IMovieRespository movieRespository, IMapper mapper)
        {
            _movieRepository = movieRespository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMovieCommand movie)
        {
            var movieDto = _mapper.Map<UpdateMovieCommand, MovieDto>(movie);
            try
            {
                await _movieRepository.Update(movieDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
