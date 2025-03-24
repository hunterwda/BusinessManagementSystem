using BusinessManagementSystem.Common.Attributes;
using BusinessManagementSystem.Core.IRepository;
using BusinessManagementSystem.Entity;
using BusinessManagementSystem.Service.IService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Service.Service
{
    public class ClientService : IClientService
    {
        private readonly ILogger<ClientService> _logger;
        private readonly IClientRepository _clientRepository;
        public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        public void AddClients(List<ClientManage> clients)
        {
            
        }

        public void DeleteClients(List<ClientManage> clients)
        {
            throw new NotImplementedException();
        }

        public void GetClients()
        {
            _logger.Log(LogLevel.Trace, "测试");
        }

        public void UpdateClients(List<ClientManage> clients)
        {
            throw new NotImplementedException();
        }
    }
}
