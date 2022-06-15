using MediatR;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist
{
    [DataContract]
    public class ReplaceWatchlist : IRequest<(string, bool)>
    {
        [DataMember]
        public ReplacementWatchlist ReplacementWatchlist { get; private set; }
        [DataMember]
        public string AccountId { get; private set; }
        public ReplaceWatchlist(ReplacementWatchlist replacementWatchlist, string accountId)
        {
            ReplacementWatchlist = replacementWatchlist;
            AccountId = accountId;
        }
    }
}
