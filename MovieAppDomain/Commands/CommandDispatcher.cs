using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Exceptions;

namespace MovieApp.Domain.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Send<T>(T command) where T : ICommand
        {
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<T>));

            if (handler == null)
                throw new HandlerNotFoundException($"Command doesn't have any handler {command.GetType().Name}");

            await ((ICommandHandler<T>)handler).Handle(command);
        }

        public Task<R> Send<T, R>(T command) where T : ICommand
        {
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<T, R>));

            if (handler == null)
                throw new HandlerNotFoundException($"Query doesn't have any handler {command.GetType().Name}");

            return ((ICommandHandler<T, R>)handler).Handle(command);
        }
    }
}
