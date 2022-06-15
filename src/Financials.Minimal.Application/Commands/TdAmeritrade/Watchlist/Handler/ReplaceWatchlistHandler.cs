using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class ReplaceWatchlistHandler : IRequestHandler<ReplaceWatchlist, (string, bool)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public ReplaceWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public async Task<(string, bool)> Handle(ReplaceWatchlist command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _watchlistProvider.ReplaceWatchlist(command.AccountId, command.ReplacementWatchlist, cancellationToken);
                return ($"{command.ReplacementWatchlist.WatchlistId} has been replaced.", true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }
    }
}
