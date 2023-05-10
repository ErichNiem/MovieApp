using MovieApp.Data.DataModels;

namespace MovieApp.Data.Interfaces
{
    public interface IMovieRespository
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<IEnumerable<MovieDto>> GetByDateRange(DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<MovieDto>> GetByIdRange(int? fromId, int? toId);
        Task<MovieDto> GetById(int movieId);
        Task<int> Add(MovieDto movie);
        Task Update(MovieDto movie);
        Task Delete(int movieId);
    }
}
