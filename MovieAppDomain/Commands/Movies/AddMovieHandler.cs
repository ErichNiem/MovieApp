using AutoMapper;
using MovieApp.Data.DataModels;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Commands.Interfaces;

namespace MovieApp.Domain.Commands.Movies
{
    public class AddMovieHandler : ICommandHandler<AddMovieCommand, int>
    {
        private readonly IMovieRespository _movieRepository;
        private readonly IMapper _mapper;
        public AddMovieHandler(IMovieRespository movieRespository, IMapper mapper) 
        {
            _movieRepository = movieRespository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddMovieCommand movie)
        {
            var movieDto = _mapper.Map<AddMovieCommand, MovieDto>(movie);
            try
            {
                return await _movieRepository.Add(movieDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
