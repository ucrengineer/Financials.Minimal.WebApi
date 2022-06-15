using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist
{
    public class GetWatchlistQuery : IRequest<(RequestedWatchlist? watchlist, string? exception)>
    {
        public GetWatchlistQuery(string accountId, string watchlistId)
        {
            AccountId = accountId;
            WatchlistId = watchlistId;
        }
        public string AccountId { get; }
        public string WatchlistId { get; }
    }

}
