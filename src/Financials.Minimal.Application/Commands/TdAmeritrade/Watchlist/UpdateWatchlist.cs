using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public record class UpdateWatchlist : Command<CommandResult>
    {
        [DataMember]
        public string AccountId { get; private set; }
        [DataMember]
        public UpdatedWatchlist UpdatedWatchlist { get; private set; }

        public UpdateWatchlist(string accountId, UpdatedWatchlist updatedWatchlist)
        {
            AccountId = accountId;
            UpdatedWatchlist = updatedWatchlist;
        }

        public override ValidationResult Validate()
        {
            return new UpdateWatchlistCommandValidator().Validate(this);

        }

    }
    public class UpdateWatchlistCommandValidator : AbstractValidator<UpdateWatchlist>
    {
        public UpdateWatchlistCommandValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId cannot be empty.")
            .MinimumLength(9);

            RuleFor(c => c.UpdatedWatchlist)
            .NotEmpty().WithMessage("Must have a updated watchlist object.");

            RuleFor(c => c.UpdatedWatchlist.WatchlistItems)
                .NotEmpty().WithMessage("Must have watchlist items in updated watchlist.");


        }
    }
}
