using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist.Handler
{
    public class GetWatchlistHandler : QueryHandler<GetWatchlist, RequestedWatchlist>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;

        public GetWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public override async Task<RequestedWatchlist> ExecuteQuery(GetWatchlist request, CancellationToken cancellationToken)
        {
            return await _watchlistProvider.GetWatchlist(request.AccountId, request.WatchlistId, cancellationToken);
        }
    }
}
