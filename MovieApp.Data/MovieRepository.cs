using Dapper;
using Microsoft.Data.SqlClient;
using MovieApp.Data.DataModels;
using MovieApp.Data.Interfaces;
using System.Data;

namespace MovieApp.Data
{
    public class MovieRepository : IMovieRespository
    {
        private readonly DapperContext _context;
        public MovieRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var query = "SELECT * FROM dbo.Movies";

            using var connection = _context.CreateConnection();

            var movies = await connection.QueryAsync<MovieDto>(query);
            return movies.ToList();
        }

        public async Task<int> Add(MovieDto movie)
        {
            var query = "INSERT INTO Movies (Title, Category, Rating, Description, DateTimeAdded, DateTimeUpdated, DateTimeDeleted) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@Title, @Category, @Rating, @Description, @DateTimeAdded, @DateTimeUpdated, @DateTimeDeleted)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", movie.Title, DbType.String);
            parameters.Add("Category", movie.Category, DbType.String);
            parameters.Add("Rating", movie.Rating, DbType.Int32);
            parameters.Add("Description", movie.Description, DbType.String);
            parameters.Add("DateTimeAdded", movie.DateTimeAdded, DbType.DateTime);
            parameters.Add("DateTimeUpdated", null, DbType.DateTime);
            parameters.Add("DateTimeDeleted", null, DbType.DateTime);

            using var connection = _context.CreateConnection();

            try
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                return id;
            }
            catch(SqlException ex)
            {
                if(ex.Number == 2627)
                    return 0;

                throw;
            }
            
        }

        public async Task<MovieDto> GetById(int movieId)
        {
            var query = "SELECT * FROM Movies WHERE id = " + movieId;

            using var connection = _context.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<MovieDto>(query);
        }

        //TODO range queries
        public Task<IEnumerable<MovieDto>> GetByDateRange(DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDto>> GetByIdRange(int? fromId, int? toId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(MovieDto movie)
        {
            var query = "UPDATE Movies SET Title = @Title, Category = @Category, Rating = @Rating, Description = @Description, DateTimeUpdated = @DateTimeUpdated WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", movie.Id, DbType.Int32);
            parameters.Add("Title", movie.Title, DbType.String);
            parameters.Add("Category", movie.Category, DbType.String);
            parameters.Add("Rating", movie.Rating, DbType.Int32);
            parameters.Add("Description", movie.Description, DbType.String);
            parameters.Add("DateTimeUpdated", movie.DateTimeUpdated, DbType.DateTime);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task Delete(int movieId)
        {
            var query = "DELETE FROM Movies WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", movieId, DbType.Int32);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
