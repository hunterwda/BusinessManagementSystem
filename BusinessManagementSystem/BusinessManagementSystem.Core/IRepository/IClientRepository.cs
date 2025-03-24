using BusinessManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Core.IRepository
{
    public interface IClientRepository
    {
        List<ClientManage> GetClients();
    }
}
