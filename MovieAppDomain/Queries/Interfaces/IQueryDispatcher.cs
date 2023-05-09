namespace MovieApp.Domain.Queries.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<List<R>> Send<T, R>(T query) where T : IQuery;

    }
}
