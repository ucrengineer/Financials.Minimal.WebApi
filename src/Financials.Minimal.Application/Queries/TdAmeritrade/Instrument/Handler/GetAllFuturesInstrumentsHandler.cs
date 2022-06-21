using TraderShop.Financials.TdAmeritrade.Instruments.Services;
using lib = TraderShop.Financials.TdAmeritrade.Abstractions.Models;


namespace Financials.Minimal.Application.Queries.TdAmeritrade.Instrument.Handler;
public class GetAllFuturesInstrumentsHandler : QueryHandler<GetAllFuturesInstruments, lib.Instrument[]>
{
    private readonly ITdAmeritradeInstrumentProvider _instrumentProvider;

    public GetAllFuturesInstrumentsHandler(ITdAmeritradeInstrumentProvider instrumentProvider)
    {
        _instrumentProvider = instrumentProvider ?? throw new ArgumentNullException(nameof(instrumentProvider));
    }

    public override async Task<lib.Instrument[]> ExecuteQuery(GetAllFuturesInstruments query, CancellationToken cancellationToken)
    {
        return await _instrumentProvider.GetAllFuturesInstruments(cancellationToken);
    }
}