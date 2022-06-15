using FluentValidation.Results;
using MediatR;

namespace Financials.Minimal.Application.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        public abstract ValidationResult Validate();
    }
}
