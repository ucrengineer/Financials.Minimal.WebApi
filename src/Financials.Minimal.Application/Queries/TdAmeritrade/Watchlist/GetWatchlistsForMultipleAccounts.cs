using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist;
[DataContract]
public record class GetWatchlistsForMultipleAccounts : Query<RequestedWatchlist[]>
{
    public override ValidationResult Validate()
    {
        return new GetWatchlistsForMultipleAccountsQueryValidator().Validate(this);
    }
}
public class GetWatchlistsForMultipleAccountsQueryValidator : AbstractValidator<GetWatchlistsForMultipleAccounts>
{
    public GetWatchlistsForMultipleAccountsQueryValidator()
    {

    }
}