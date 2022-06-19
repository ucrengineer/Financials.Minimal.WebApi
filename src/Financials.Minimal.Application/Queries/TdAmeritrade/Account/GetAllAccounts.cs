using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Account
{
    [DataContract]
    public record class GetAllAccounts : Query<SecuritiesAccount[]>
    {
        [DataMember]
        public string? Fields { get; private set; }

        public GetAllAccounts(string? fields)
        {
            Fields = fields;
        }

        public override ValidationResult Validate()
        {
            return new GetAllAccountsQueryValidator().Validate(this);
        }
    }

    public class GetAllAccountsQueryValidator : AbstractValidator<GetAllAccounts>
    {
        private string[] validFields { get; } = new string[] { "positions", "orders", "positions,orders", "orders,positions" };
        public GetAllAccountsQueryValidator()
        {
            When(x => x.Fields != null, () =>
            {
                RuleFor(c => c.Fields)
                    .Must(x => validFields.Any(y => y.Equals(x)))
                    .WithMessage("Additional fields can only be positions and/or orders");
            });
        }
    }

}
