using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using lib = TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Instrument;

[DataContract]
public record class GetInstrument : Query<lib.Instrument>
{
    [DataMember]
    public string Symbol { get; private set; }

    public GetInstrument(string symbol)
    {
        Symbol = symbol;
    }

    public override ValidationResult Validate()
    {
        return new GetInstrumentQueryValidator().Validate(this);
    }
}

public class GetInstrumentQueryValidator : AbstractValidator<GetInstrument>
{
    public GetInstrumentQueryValidator()
    {
        RuleFor(x => x.Symbol)
            .NotEmpty();
    }
}