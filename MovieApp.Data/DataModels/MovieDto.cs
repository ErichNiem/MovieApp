namespace MovieApp.Data.DataModels
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Rating { get; set; }
        public string? Description { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public DateTime DateTimeDeleted { get; set; }
    }
}
