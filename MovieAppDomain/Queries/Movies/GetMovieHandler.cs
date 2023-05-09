using AutoMapper;
using MovieApp.Data.DataModels;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Models;
using MovieApp.Domain.Queries.Interfaces;

namespace MovieApp.Domain.Queries.Movies
{
    public class GetMovieHandler : IQueryHandler<GetMovieQuery, Movie>
    {
        private readonly IMovieRespository _movieRespository;
        private readonly IMapper _mapper;

        public GetMovieHandler(IMovieRespository movieRespository, IMapper mapper)
        {
            _movieRespository = movieRespository;
            _mapper = mapper;
        }
        public async Task<List<Movie>> Handle(GetMovieQuery command)
        {
            var movieDto = await _movieRespository.GetById(command.Id);

            var movieDtoList = new List<MovieDto>();

            movieDtoList.Add(movieDto);

            return _mapper.Map<List<MovieDto>, List<Movie>>(movieDtoList);
        }

    }
}
