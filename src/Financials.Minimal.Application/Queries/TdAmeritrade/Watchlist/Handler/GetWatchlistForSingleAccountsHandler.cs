using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist.Handler
{
    public class GetWatchlistForSingleAccountsHandler : QueryHandler<GetWatchlistsForSingleAccounts, RequestedWatchlist[]>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public GetWatchlistForSingleAccountsHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider ?? throw new ArgumentNullException(nameof(watchlistProvider)); ;
        }

        public override async Task<RequestedWatchlist[]> ExecuteQuery(GetWatchlistsForSingleAccounts request, CancellationToken cancellationToken)
        {
            return await _watchlistProvider.GetWatchlistsForSingleAccounts(request.AccountId, cancellationToken);
        }
    }
}
