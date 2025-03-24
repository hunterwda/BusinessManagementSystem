using BusinessManagementSystem.Common.Attributes;
using BusinessManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Service.IService
{
    public interface IClientService
    {
        void GetClients();
        void AddClients(List<ClientManage> clients);
        void UpdateClients(List<ClientManage> clients);
        void DeleteClients(List<ClientManage> clients);
    }
}
