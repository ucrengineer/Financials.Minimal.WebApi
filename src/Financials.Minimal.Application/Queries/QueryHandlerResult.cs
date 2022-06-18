using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Financials.Minimal.Application.Queries
{
    public record class QueryHandlerResult<TResult>
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; }

        [JsonIgnore]
        public TResult Result { get; set; }

        public QueryHandlerResult(IQuery<QueryHandlerResult<TResult>> query)
        {
            ValidationResult = query.Validate();
        }
    }
}
