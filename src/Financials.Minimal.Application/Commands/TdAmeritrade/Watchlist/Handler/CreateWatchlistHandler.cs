using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist.Handler
{
    public class CreateWatchlistHandler : IRequestHandler<CreateWatchlist, (string, bool)>
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;

        public CreateWatchlistHandler(ITdAmeritradeWatchlistProvider watchlistProvider)
        {
            _watchlistProvider = watchlistProvider;
        }

        public async Task<(string, bool)> Handle(CreateWatchlist command, CancellationToken cancellationToken)
        {
            var validationResult = command.Validate();

            if (validationResult.IsValid)
            {
                try
                {
                    await _watchlistProvider.CreateWatchlist(command.AccountId, command.CreatedWatchlist, cancellationToken);
                    return ($"{command.CreatedWatchlist.Name} created.", true);
                }
                catch (Exception ex)
                {
                    return (ex.Message, false);
                }
            }
            return (string.Join(",", validationResult.Errors), false);

        }
    }
}
