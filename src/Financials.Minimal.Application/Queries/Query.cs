using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Financials.Minimal.Application.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        public abstract ValidationResult Validate();
    }

    public abstract record class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; init; }

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
