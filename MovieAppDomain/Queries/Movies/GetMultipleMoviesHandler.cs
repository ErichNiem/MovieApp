using AutoMapper;
using MovieApp.Data.DataModels;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Models;
using MovieApp.Domain.Queries.Interfaces;

namespace MovieApp.Domain.Queries.Movies
{
    public class GetMultipleMoviesHandler : IQueryHandler<GetMultipleMoviesQuery, Movie>
    {
        private readonly IMovieRespository _movieRespository;
        private readonly IMapper _mapper;

        public GetMultipleMoviesHandler(IMovieRespository movieRespository, IMapper mapper)
        {
            _movieRespository = movieRespository;
            _mapper = mapper;
        }

        public async Task<List<Movie>> Handle(GetMultipleMoviesQuery command)
        {
            if (command.FromDate == null && command.FromId == null)
            {
                
                var movieDtoList = await _movieRespository.GetAll();

                return _mapper.Map<List<MovieDto>, List<Movie>>(movieDtoList.ToList());
            }

            return new List<Movie>();
        }
    }
}
