using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class ReplaceWatchlistHandler : CommandHandler<ReplaceWatchlist, CommandResult>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public ReplaceWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider ?? throw new ArgumentNullException(nameof(watchlistProvider)); ;
        }

        public override async Task<CommandResult> ExecuteCommand(ReplaceWatchlist command, CancellationToken cancellationToken)
        {
            await _watchlistProvider.ReplaceWatchlist(command.AccountId, command.ReplacementWatchlist, cancellationToken);
            return new CommandResult($"{command.ReplacementWatchlist.WatchlistId} replaced.", true);
        }
    }
}
