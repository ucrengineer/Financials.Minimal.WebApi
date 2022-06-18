using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist
{
    [DataContract]
    public record class GetWatchlistsForSingleAccounts : Query<RequestedWatchlist[]>
    {
        [DataMember]
        public string AccountId { get; }
        public GetWatchlistsForSingleAccounts(string accountId)
        {
            AccountId = accountId;
        }

        public override ValidationResult Validate()
        {
            return new GetWatchlistsForSingleAccountsQueryValidator().Validate(this);
        }
    }
    public class GetWatchlistsForSingleAccountsQueryValidator : AbstractValidator<GetWatchlistsForSingleAccounts>
    {
        public GetWatchlistsForSingleAccountsQueryValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId cannot be empty.")
            .MinimumLength(9);
        }
    }
}
