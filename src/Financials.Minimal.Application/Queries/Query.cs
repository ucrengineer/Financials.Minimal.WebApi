using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Financials.Minimal.Application.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
        public abstract ValidationResult Validate();
    }
}
