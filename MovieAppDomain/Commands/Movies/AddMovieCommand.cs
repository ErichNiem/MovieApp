using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Models;

namespace MovieApp.Domain.Commands.Movies
{
    public class AddMovieCommand : Movie, ICommand
    {
        public DateTime DateTimeAdded { get; set; } = DateTime.Now;
    }
}
