using BusinessManagementSystem.Common.Cofing;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Common.Sugar
{
    public static class SugarExtended
    {
        public static void AddSqlSugarUnitSetupSetup(this IServiceCollection services)
        {
            var configSettings = ConfigExtended.GetConfigSettings();
            services.AddSingleton<ISqlSugarClient>(s =>
            {
                var Db = new SqlSugarScope(configSettings, 
                    db =>
                    {
                        configSettings.ForEach(i =>
                        {
                            db.GetConnection(i.ConfigId).Aop.OnLogExecuting = (sql, p) =>
                            {
                                Console.WriteLine(sql);
                            };
                        });
                    });
                return Db;
            });
            services.AddScoped(typeof(Repository<>));
        }
    }
}
