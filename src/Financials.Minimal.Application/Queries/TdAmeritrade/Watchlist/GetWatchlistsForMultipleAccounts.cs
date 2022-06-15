using MediatR;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist
{
    public class GetWatchlistsForMultipleAccounts : IRequest<(RequestedWatchlist[]? watchlists, string? exception)>
    {
    }
}
