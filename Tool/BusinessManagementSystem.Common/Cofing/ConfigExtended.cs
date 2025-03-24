using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace BusinessManagementSystem.Common.Cofing
{
    public class ConfigExtended
    {
        public static List<ConnectionConfig> GetConfigSettings()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var result = configuration.GetSection("Release:ConnectionStrings")
                .GetChildren()
                .Select(MapToConnectionConfig)
                .ToList();

            return result;
        }

        private static ConnectionConfig MapToConnectionConfig(IConfigurationSection section)
        {
            var configId = section["DatabaseKey"];
            var dbTypeString = section["DatabaseType"];
            var connectionString = section["DatabaseConnectionString"];

            if (string.IsNullOrEmpty(configId) || string.IsNullOrEmpty(dbTypeString) || string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("缺少连接所需的配置值!");
            }

            return new ConnectionConfig
            {
                ConfigId = configId,
                DbType = ParseDbType(dbTypeString),
                ConnectionString = connectionString,
                IsAutoCloseConnection = true
            };
        }

        private static DbType ParseDbType(string dbTypeString)
        {
            return dbTypeString?.ToUpperInvariant() switch
            {
                "MYSQL" => DbType.MySql,
                "SQLSERVER" => DbType.SqlServer,
                _ => throw new ArgumentException($"不支持数据库: {dbTypeString}!", nameof(dbTypeString))
            };
        }
    }
}
