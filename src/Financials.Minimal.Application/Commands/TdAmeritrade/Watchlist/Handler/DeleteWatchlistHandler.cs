using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class DeleteWatchlistHandler : CommandHandler<DeleteWatchlist, CommandResult>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public DeleteWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public override async Task<CommandResult> ExecuteCommand(DeleteWatchlist command, CancellationToken cancellationToken)
        {
            await _watchlistProvider.DeleteWatchlist(command.AccountId, command.WatchlistId, cancellationToken);
            return new CommandResult($"{command.WatchlistId} deleted.", true);
        }
    }
}
