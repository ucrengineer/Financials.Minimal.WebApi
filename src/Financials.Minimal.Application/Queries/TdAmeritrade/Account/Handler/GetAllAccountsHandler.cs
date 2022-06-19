using TraderShop.Financials.TdAmeritrade.Accounts.Models;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Account.Handler
{
    public class GetAllAccountsHandler : QueryHandler<GetAllAccounts, SecuritiesAccount[]>
    {
        private readonly ITdAmeritradeAccountProvider _accountsProvider;

        public GetAllAccountsHandler(ITdAmeritradeAccountProvider accountsProvider)
        {
            _accountsProvider = accountsProvider;
        }

        public override async Task<SecuritiesAccount[]> ExecuteQuery(GetAllAccounts query, CancellationToken cancellationToken)
        {
            return await _accountsProvider.GetAccounts(query.Fields);
        }
    }
}
