using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public record class ReplaceWatchlist : Command<CommandResult>
    {
        [DataMember]
        public ReplacementWatchlist ReplacementWatchlist { get; private set; }
        [DataMember]
        public string AccountId { get; private set; }
        public ReplaceWatchlist(ReplacementWatchlist replacementWatchlist, string accountId)
        {
            ReplacementWatchlist = replacementWatchlist;
            AccountId = accountId;
        }

        public override ValidationResult Validate()
        {
            return new ReplaceWatchlistCommandValidator().Validate(this);
        }
    }

    public class ReplaceWatchlistCommandValidator : AbstractValidator<ReplaceWatchlist>
    {
        public ReplaceWatchlistCommandValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId cannot be empty.")
            .Must(x => int.TryParse(x, out var result));


            RuleFor(c => c.ReplacementWatchlist)
            .NotEmpty().WithMessage("Must have a replacement watchlist object.");

            RuleFor(c => c.ReplacementWatchlist.WatchlistItems)
                .NotEmpty().WithMessage("Must have watchlist items in replacement watchlist.");

        }
    }
}
