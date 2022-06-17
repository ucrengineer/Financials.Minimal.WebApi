using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class UpdateWatchlistHandler : IRequestHandler<UpdateWatchlist, (string, bool)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public UpdateWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }
        public async Task<(string, bool)> Handle(UpdateWatchlist request, CancellationToken cancellationToken)
        {
            var validation = request.Validate();
            if (validation.IsValid)
            {
                try
                {
                    var result = await _watchlistProvider.UpdateWatchlist(request.AccountId, request.UpdatedWatchlist, cancellationToken);
                    return ($"{request.UpdatedWatchlist.Name} updated successfully.", true);
                }
                catch (Exception ex)
                {
                    return (ex.Message, false);
                }
            }

            return (string.Join(",", validation.Errors), false);
        }
    }
}
