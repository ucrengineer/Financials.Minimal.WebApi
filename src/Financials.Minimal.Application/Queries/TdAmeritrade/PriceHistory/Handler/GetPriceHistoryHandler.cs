using Financials.Minimal.WebApi.Models;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.PriceHistory.Handler
{
    public class GetPriceHistoryHandler : QueryHandler<GetPriceHistory, Candle[]>
    {
        private readonly ITdAmeritradePriceHistoryProvider _priceHistoryProvider;

        public GetPriceHistoryHandler(ITdAmeritradePriceHistoryProvider priceHistoryProvider)
        {
            _priceHistoryProvider = priceHistoryProvider ?? throw new ArgumentNullException(nameof(priceHistoryProvider));
        }

        public override async Task<Candle[]> ExecuteQuery(GetPriceHistory query, CancellationToken cancellationToken)
        {
            return await _priceHistoryProvider.GetPriceHistory(query.Symbol, query.Specs.Map(), cancellationToken);
        }
    }
}
