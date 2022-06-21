using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist.Handler
{
    public class GetWatchlistForMultipleAccountsHandler : QueryHandler<GetWatchlistsForMultipleAccounts, RequestedWatchlist[]>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public GetWatchlistForMultipleAccountsHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider ?? throw new ArgumentNullException(nameof(watchlistProvider)); ;
        }

        public override async Task<RequestedWatchlist[]> ExecuteQuery(GetWatchlistsForMultipleAccounts request, CancellationToken cancellationToken)
        {
            return await _watchlistProvider.GetWatchlistsForMultipleAccounts(cancellationToken);
        }
    }
}
