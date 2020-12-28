using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;

namespace TechnoShop.DAL
{
    public class MagasinConfiguration : DbConfiguration
    {
        public MagasinConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new MagasinInterceptorTransientErrors());
            DbInterception.Add(new MagasinInterceptorLogging());
        }


    }
}