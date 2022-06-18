using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public record class CreateWatchlist : Command<CommandResult>
    {
        [DataMember]
        public string AccountId { get; private set; }

        [DataMember]
        public CreatedWatchlist CreatedWatchlist { get; private set; }

        public CreateWatchlist(string accountId, CreatedWatchlist createdWatchlist)
        {
            AccountId = accountId;
            CreatedWatchlist = createdWatchlist;
        }

        public override ValidationResult Validate()
        {
            return new CreateWatchlistCommandValidator().Validate(this);
        }
    }

    public class CreateWatchlistCommandValidator : AbstractValidator<CreateWatchlist>
    {
        public CreateWatchlistCommandValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId cannot be empty.")
            .MinimumLength(9);

            RuleFor(c => c.CreatedWatchlist)
            .NotEmpty().WithMessage("Must have a createdWatchlist object.");

            RuleFor(c => c.CreatedWatchlist.WatchlistItems)
                .NotEmpty().WithMessage("Must have watchlist items in new watchlist.");

        }
    }
}
