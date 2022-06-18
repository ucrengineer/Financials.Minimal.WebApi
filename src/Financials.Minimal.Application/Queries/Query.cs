using FluentValidation.Results;
using MediatR;

namespace Financials.Minimal.Application.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        public abstract ValidationResult Validate();
    }

    public abstract record class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
    {
        public ValidationResult ValidationResult { get; init; }

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
