using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class DeleteWatchlistHandler : IRequestHandler<DeleteWatchlist, (string, bool)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public DeleteWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public async Task<(string, bool)> Handle(DeleteWatchlist command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _watchlistProvider.DeleteWatchlist(command.AccountId, command.WatchlistId, cancellationToken);
                return ($"{command.WatchlistId} deleted.", true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }
    }
}
