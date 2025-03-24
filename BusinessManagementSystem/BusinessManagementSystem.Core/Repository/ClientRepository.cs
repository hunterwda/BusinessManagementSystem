using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Core.IRepository;
using BusinessManagementSystem.Entity;

namespace BusinessManagementSystem.Core.Repository
{
    public class ClientRepository : IClientRepository
    {
        public readonly Repository<ClientManage> _clientRepository;
        public ClientRepository(Repository<ClientManage> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ClientManage> GetClients()
        {
            return _clientRepository.GetList();
        }
    }
}
