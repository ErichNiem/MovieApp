using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Models;

namespace MovieApp.Domain.Commands.Movies
{
    public class DeleteMovieCommand : Movie, ICommand
    {
        public DateTime DateTimeDeleted { get; set; } = DateTime.Now;
        public bool SoftDelete { get; set; }
    }
}

