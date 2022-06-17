using MediatR;

namespace Financials.Minimal.Application.Commands
{
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    { }

    public abstract class CommandHandler<TCommand, T> : ICommandHandler<TCommand, CommandHandlerResult<T>>
        where TCommand : ICommand<CommandHandlerResult<T>>
        where T : struct
    {
        public abstract Task<T> ExecuteCommand(TCommand command, CancellationToken cancellationToken);
        public async Task<CommandHandlerResult<T>> Handle(TCommand command, CancellationToken cancellationToken)
        {
            CommandHandlerResult<T> result = new CommandHandlerResult<T>(command);
            try
            {
                if (result.ValidationResult.IsValid)
                    result.Result = await ExecuteCommand(command, cancellationToken);

            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
