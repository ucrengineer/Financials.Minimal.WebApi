using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public class CreateWatchlist : ICommand<(string, bool)>
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

        public ValidationResult Validate()
        {
            return new CreatedWatchlistCommandValidator().Validate(this);
        }
    }
    public class CreatedWatchlistCommandValidator : AbstractValidator<CreateWatchlist>
    {
        public CreatedWatchlistCommandValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId is empty.");

            RuleFor(c => c.CreatedWatchlist)
            .NotEmpty().WithMessage("Must have a createdWatchlist");

        }
    }
}
