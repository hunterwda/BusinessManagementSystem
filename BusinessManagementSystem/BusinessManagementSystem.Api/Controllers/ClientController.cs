using BusinessManagementSystem.Entity;
using BusinessManagementSystem.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagementSystem.Api.Controllers
{
    public class ClientController
    {
        public readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// 获取估墨数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetClients")]
        [ProducesResponseType(typeof(ClientManage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status501NotImplemented)]
        public void GetClients()
        {
            _clientService.GetClients();
        }
    }
}
