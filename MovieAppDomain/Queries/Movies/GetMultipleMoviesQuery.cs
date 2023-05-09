using MovieApp.Domain.Models;
using MovieApp.Domain.Queries.Interfaces;

namespace MovieApp.Domain.Queries.Movies
{
    public class GetMultipleMoviesQuery : List<Movie>, IQuery
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
    }
}
