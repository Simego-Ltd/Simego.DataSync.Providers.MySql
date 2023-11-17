using Simego.DataSync.Providers.Ado;
using System;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Simego.DataSync.Providers.MySQL
{
    [ProviderInfo(Name = "MySQL (8.2.0)", Group = "SQL", Description = "MySql.Data.MySqlClient .NET Library from Oracle")]
    public class MySqlDatasourceReader : AdoDataSourceReader
    {
        private Lazy<AdoDbProviderFactory> MyFactory => new Lazy<AdoDbProviderFactory>(() => new AdoDbProviderFactory("MySql.Data", GetFactory()));
        
        protected override bool IsCustomAdoProvider() => true;

        public override AdoDbProviderFactory GetProviderFactory(string providerInvariantName) => MyFactory.Value;

        private static DbProviderFactory GetFactory()
        {
            var factoryType = typeof(MySqlClientFactory); 

            return factoryType.InvokeMember(factoryType.Name,
               BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
               null, null, null, CultureInfo.CurrentCulture) as DbProviderFactory;            
        }
    }
}
