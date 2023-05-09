using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Models;

namespace MovieApp.Domain.Commands.Movies
{
    public class UpdateMovieCommand : Movie, ICommand
    {
        public DateTime DateTimeUpdated { get; set; } = DateTime.Now;
    }
}

