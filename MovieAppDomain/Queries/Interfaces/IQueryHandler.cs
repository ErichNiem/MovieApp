using MovieApp.Domain.Commands.Interfaces;

namespace MovieApp.Domain.Queries.Interfaces
{
    public interface IQueryHandler
    {

    }
    public interface IQueryHandler<T> where T : IQuery
    {
        Task Handle(T query);
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler where TQuery : IQuery
    {
        Task<List<TResult>> Handle(TQuery query);
    }
}
