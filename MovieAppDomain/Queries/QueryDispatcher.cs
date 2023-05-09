using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Exceptions;
using MovieApp.Domain.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<List<R>> Send<T, R>(T query) where T : IQuery
        {
            var handler = _serviceProvider.GetService(typeof(IQueryHandler<T, R>));

            if (handler == null)
                throw new HandlerNotFoundException($"Query doesn't have any handler {query.GetType().Name}");

            return ((IQueryHandler<T, R>)handler).Handle(query);
        }
    }
}
