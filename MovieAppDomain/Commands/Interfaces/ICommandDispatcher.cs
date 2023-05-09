namespace MovieApp.Domain.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        Task Send<T>(T command) where T : ICommand;
        Task<R> Send<T, R>(T command) where T : ICommand;
    }
}