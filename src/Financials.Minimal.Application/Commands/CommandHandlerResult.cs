using FluentValidation.Results;

namespace Financials.Minimal.Application.Commands
{
    public interface ICommandHandlerResult
    {
        public ValidationResult ValidationResult { get; set; }
    }
    public sealed record class CommandHandlerResult<T> : ICommandHandlerResult
        where T : struct
    {
        public T Result { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public CommandHandlerResult(ICommand<ICommandHandlerResult> command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            ValidationResult = command.Validate();
        }
    }
}
