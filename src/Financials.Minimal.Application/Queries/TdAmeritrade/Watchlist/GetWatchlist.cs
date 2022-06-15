using MediatR;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist
{
    [DataContract]
    public class GetWatchlist : IRequest<(RequestedWatchlist? watchlist, string? exception)>
    {
        [DataMember]
        public string AccountId { get; }
        [DataMember]
        public string WatchlistId { get; }

        public GetWatchlist(string accountId, string watchlistId)
        {
            AccountId = accountId;
            WatchlistId = watchlistId;
        }

    }

}
