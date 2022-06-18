using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class CreateWatchlistHandler : CommandHandler<CreateWatchlist, CommandResult>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;

        public CreateWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public override async Task<CommandResult> ExecuteCommand(CreateWatchlist command, CancellationToken cancellationToken)
        {
            await _watchlistProvider.CreateWatchlist(command.AccountId, command.CreatedWatchlist, cancellationToken);
            return new CommandResult($"{command.CreatedWatchlist.Name} created.", true);
        }
    }
}
