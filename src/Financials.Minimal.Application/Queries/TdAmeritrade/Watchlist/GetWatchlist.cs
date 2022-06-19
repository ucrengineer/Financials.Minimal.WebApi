using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist
{
    [DataContract]
    public record class GetWatchlist : Query<RequestedWatchlist>
    {
        [DataMember]
        public string AccountId { get; }
        [DataMember]
        public string WatchlistId { get; }

        public GetWatchlist(string accountId, string watchlistId)
        {
            AccountId = accountId;
            WatchlistId = watchlistId;
        }

        public override ValidationResult Validate()
        {
            return new GetWatchlistQueryValidator().Validate(this);
        }
    }

    public class GetWatchlistQueryValidator : AbstractValidator<GetWatchlist>
    {
        public GetWatchlistQueryValidator()
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
