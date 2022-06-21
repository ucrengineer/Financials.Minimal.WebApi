using TraderShop.Financials.TdAmeritrade.Accounts.Models;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Account.Handler
{
    public class GetAllAccountsHandler : QueryHandler<GetAllAccounts, SecuritiesAccount[]>
    {
        private readonly ITdAmeritradeAccountProvider _accountProvider;

        public GetAllAccountsHandler(ITdAmeritradeAccountProvider accountProvider)
        {
            _accountProvider = accountProvider ?? throw new ArgumentNullException(nameof(accountProvider));
        }

        public override async Task<SecuritiesAccount[]> ExecuteQuery(GetAllAccounts query, CancellationToken cancellationToken)
        {
            return await _accountProvider.GetAccounts(query.Fields);
        }
    }
}
