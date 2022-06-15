using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist
{
    public class GetWatchlistsForSingleAccounts : IRequest<(RequestedWatchlist[]? watchlists, string? exception)>
    {
        public string AccountId { get; }
        public GetWatchlistsForSingleAccounts(string accountId)
        {
            AccountId = accountId;
        }
    }
}
