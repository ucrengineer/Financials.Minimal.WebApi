using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public record class DeleteWatchlist : Command<CommandResult>
    {
        [DataMember]
        public string AccountId { get; private set; }
        [DataMember]
        public string WatchlistId { get; private set; }
        public DeleteWatchlist(string accountId, string watchlistId)
        {
            AccountId = accountId;
            WatchlistId = watchlistId;
        }

        public override ValidationResult Validate()
        {
            return new DeleteWatchlistCommandValidator().Validate(this);
        }
    }
    public class DeleteWatchlistCommandValidator : AbstractValidator<DeleteWatchlist>
    {
        public DeleteWatchlistCommandValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId cannot be empty.")
            .MinimumLength(9)
            .Must(x => int.TryParse(x, out var result));


            RuleFor(c => c.WatchlistId)
            .NotEmpty().WithMessage("WatchlistId cannot be empty")
            .MinimumLength(10)
            .Must(x => int.TryParse(x, out var result));


        }
    }
}
