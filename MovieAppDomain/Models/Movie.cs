namespace MovieApp.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Rating { get; set; }
        public string Description { get; set; } = default!;

    }
}
