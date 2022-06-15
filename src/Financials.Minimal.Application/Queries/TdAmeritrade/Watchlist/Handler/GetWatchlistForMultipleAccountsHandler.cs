using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist.Handler
{
    public class GetWatchlistForMultipleAccountsHandler : IRequestHandler<GetWatchlistsForMultipleAccounts, (RequestedWatchlist[]? watchlists, string? message)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public GetWatchlistForMultipleAccountsHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public async Task<(RequestedWatchlist[]? watchlists, string? message)> Handle(GetWatchlistsForMultipleAccounts request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _watchlistProvider.GetWatchlistsForMultipleAccounts(cancellationToken);
                return (result, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
