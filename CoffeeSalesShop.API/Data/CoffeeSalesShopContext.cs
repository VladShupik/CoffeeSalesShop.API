using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeSalesShop.API.Data;

public class CoffeeSalesShopContext
{
    private ConnectionStringOptions connectionStringOptions;
    public CoffeeSalesShopContext(IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
    {
        connectionStringOptions = optionsMonitor.CurrentValue;
    }
    public IDbConnection CreateConnection() => new SqlConnection(connectionStringOptions.CoffeeSalesShop);
}

