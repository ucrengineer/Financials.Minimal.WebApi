using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public class UpdateWatchlist : ICommand<(string, bool)>
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

        public ValidationResult Validate()
        {
            return new UpdateWatchlistCommandValidator().Validate(this);

        }

    }
    public class UpdateWatchlistCommandValidator : AbstractValidator<UpdateWatchlist>
    {
        public UpdateWatchlistCommandValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId is empty.");

            RuleFor(c => c.UpdatedWatchlist)
            .NotEmpty().WithMessage("Must have a updatedWatchlist");

        }
    }
}
