namespace MovieApp.Domain.Commands.Interfaces
{
    public interface ICommandHandler
    {

    }
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        Task Handle(T command);
    }

    public interface ICommandHandler<TCommand, TResult> : ICommandHandler where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}