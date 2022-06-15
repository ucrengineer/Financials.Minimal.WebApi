using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist.Handler
{
    public class GetWatchlistHandler : IRequestHandler<GetWatchlistQuery, (RequestedWatchlist? watchlist, string? exception)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;

        public GetWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public async Task<(RequestedWatchlist? watchlist, string? exception)> Handle(GetWatchlistQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _watchlistProvider.GetWatchlist(request.AccountId, request.WatchlistId, cancellationToken);
                return (result, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
