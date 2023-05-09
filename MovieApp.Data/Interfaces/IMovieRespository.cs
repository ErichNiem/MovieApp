using MovieApp.Data.DataModels;

namespace MovieApp.Data.Interfaces
{
    public interface IMovieRespository
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<IEnumerable<MovieDto>> GetByDateRange(DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<MovieDto>> GetByIdRange(int? fromId, int? toId);
        public Task<MovieDto> GetById(int movieId);
        public Task<int> Add(MovieDto movie);
        public Task Update(MovieDto movie);
        public Task Delete(int movieId);
    }
}
