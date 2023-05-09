using MovieApp.Domain.Models;
using MovieApp.Domain.Queries.Interfaces;

namespace MovieApp.Domain.Queries.Movies
{
    public class GetMovieQuery : Movie, IQuery
    {
        public DateTime DateTimeAdded { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public DateTime DateTimeDeleted { get; set; }
    }
}
