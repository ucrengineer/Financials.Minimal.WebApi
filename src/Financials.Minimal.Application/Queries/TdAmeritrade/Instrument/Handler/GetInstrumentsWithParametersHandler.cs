using TraderShop.Financials.TdAmeritrade.Instruments.Models;
using TraderShop.Financials.TdAmeritrade.Instruments.Services;
using lib = TraderShop.Financials.TdAmeritrade.Abstractions.Models;


namespace Financials.Minimal.Application.Queries.TdAmeritrade.Instrument.Handler
{
    public class GetInstrumentsWithParametersHandler : QueryHandler<GetInstrumentsWithParameters, lib.Instrument[]>
    {
        private readonly ITdAmeritradeInstrumentProvider _instrumentProvider;

        public GetInstrumentsWithParametersHandler(ITdAmeritradeInstrumentProvider instrumentProvider)
        {
            _instrumentProvider = instrumentProvider ?? throw new ArgumentNullException(nameof(instrumentProvider));
        }

        public override async Task<lib.Instrument[]> ExecuteQuery(GetInstrumentsWithParameters query, CancellationToken cancellationToken)
        {
            return await _instrumentProvider.GetInstruments(query.Symbol, Projection.FromName(query.Projection), cancellationToken);
        }
    }
}
