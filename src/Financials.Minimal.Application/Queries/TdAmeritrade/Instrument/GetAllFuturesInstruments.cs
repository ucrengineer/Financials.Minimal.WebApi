using FluentValidation;
using FluentValidation.Results;
using lib = TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Instrument;
public record class GetAllFuturesInstruments : Query<lib.Instrument[]>
{
    public GetAllFuturesInstruments()
    {
    }

    public override ValidationResult Validate()
    {
        return new GetAllFuturesInstrumentsQueryValidator().Validate(this);
    }
}

public class GetAllFuturesInstrumentsQueryValidator : AbstractValidator<GetAllFuturesInstruments>
{
    public GetAllFuturesInstrumentsQueryValidator()
    {
    }
}