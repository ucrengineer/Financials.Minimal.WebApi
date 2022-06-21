using TraderShop.Financials.TdAmeritrade.Instruments.Services;
using lib = TraderShop.Financials.TdAmeritrade.Abstractions.Models;


namespace Financials.Minimal.Application.Queries.TdAmeritrade.Instrument.Handler
{
    public class GetInstrumentHandler : QueryHandler<GetInstrument, lib.Instrument>
    {
        private readonly ITdAmeritradeInstrumentProvider _instrumentProvider;

        public GetInstrumentHandler(ITdAmeritradeInstrumentProvider instrumentProvider)
        {
            _instrumentProvider = instrumentProvider ?? throw new ArgumentNullException(nameof(instrumentProvider));
        }

        public override async Task<lib.Instrument> ExecuteQuery(GetInstrument query, CancellationToken cancellationToken)
        {
            return await _instrumentProvider.GetInstrument(query.Symbol, cancellationToken);
        }
    }
}
