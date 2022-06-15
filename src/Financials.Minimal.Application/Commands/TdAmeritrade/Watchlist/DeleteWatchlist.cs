using MediatR;
using System.Runtime.Serialization;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public class DeleteWatchlist : IRequest<(string, bool)>
    {
        [DataMember]
        public string AccountId { get; private set; }
        [DataMember]
        public string WatchlistId { get; private set; }
        public DeleteWatchlist(string accountId, string watchlistId)
        {
            AccountId = accountId;
            WatchlistId = watchlistId;
        }
    }
}
