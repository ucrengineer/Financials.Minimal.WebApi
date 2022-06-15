using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist.Handler
{
    public class GetWatchlistForSingleAccountsHandler : IRequestHandler<GetWatchlistsForSingleAccounts, (RequestedWatchlist[]? watchlists, string? exception)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public GetWatchlistForSingleAccountsHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public async Task<(RequestedWatchlist[]? watchlists, string? exception)> Handle(GetWatchlistsForSingleAccounts request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _watchlistProvider.GetWatchlistsForSingleAccounts(request.AccountId, cancellationToken);
                return (result, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
