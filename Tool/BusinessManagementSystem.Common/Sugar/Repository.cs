using BusinessManagementSystem.Common.Attributes;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Common.Sugar
{
    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        public ITenant itenant = null;//多租户事务、GetConnection、IsAnyConnection等功能
        public Repository(ISqlSugarClient db)
        {
            itenant = db.AsTenant();//用来处理事务
            base.Context = db.AsTenant().GetConnectionScopeWithAttr<T>();//获取子Db
        }
    }
}
