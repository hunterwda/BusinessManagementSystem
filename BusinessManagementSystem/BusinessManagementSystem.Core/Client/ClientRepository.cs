using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Core.Client
{
    public class ClientRepository
    {
        public readonly Repository<Client> _clientRepository;
        public ClientRepository(Repository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetClients()
        {
            return _clientRepository.GetList();
        }
    }

    public class Client
    {
        public string Name { get; set; }
    }
}
