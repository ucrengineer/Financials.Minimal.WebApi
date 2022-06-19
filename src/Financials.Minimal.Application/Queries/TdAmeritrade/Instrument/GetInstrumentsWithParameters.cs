using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.Instruments.Models;
using lib = TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Instrument;
[DataContract]
public record class GetInstrumentsWithParameters : Query<lib.Instrument[]>
{
    [DataMember]
    public string Symbol { get; private set; }
    [DataMember]
    public string Projection { get; private set; }

    public GetInstrumentsWithParameters(string symbol, string projection)
    {
        Symbol = symbol;
        Projection = projection;
    }

    public override ValidationResult Validate()
    {
        return new GetInstrumentsWithParametersQueryValidator().Validate(this);
    }
}

public class GetInstrumentsWithParametersQueryValidator : AbstractValidator<GetInstrumentsWithParameters>
{
    public string validProjections { get; } =
        "symbol-search, symbol-regex, desc-search, desc-regex, fundamental";
    public GetInstrumentsWithParametersQueryValidator()
    {
        RuleFor(x => x.Symbol)
            .NotEmpty();

        RuleFor(x => x.Projection)
            .Must(x => Projection.TryFromName(x, true, out var result))
            .WithMessage($"Invalid Projection. Valid inputs for projections are : {validProjections}")
            .NotEmpty();
    }
}

