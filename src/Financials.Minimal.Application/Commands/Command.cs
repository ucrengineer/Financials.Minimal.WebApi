using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Financials.Minimal.Application.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        public abstract ValidationResult Validate();
    }

    public abstract record class Command<T> : ICommand<CommandHandlerResult<T>>
        where T : struct
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; init; }

        [JsonIgnore]
        public T Result { get; init; }

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
