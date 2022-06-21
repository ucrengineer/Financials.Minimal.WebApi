using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class UpdateWatchlistHandler : CommandHandler<UpdateWatchlist, CommandResult>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        public UpdateWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider ?? throw new ArgumentNullException(nameof(watchlistProvider)); ;
        }
        public override async Task<CommandResult> ExecuteCommand(UpdateWatchlist request, CancellationToken cancellationToken)
        {
            await _watchlistProvider.UpdateWatchlist(request.AccountId, request.UpdatedWatchlist, cancellationToken);
            return new CommandResult($"{request.UpdatedWatchlist.Name} updated.", true);
        }
    }
}
