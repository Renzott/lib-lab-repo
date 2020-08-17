using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creditos_backend.Models;
using creditos_backend.Repositories;
using creditos_backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace creditos_backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClientRepository _clientRepository;

        public ClienteController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetListClientes()
        {
            var item = await _clientRepository.getListClient();

            return item != null ? Ok(item) : (ActionResult)NotFound();
        }

        [HttpPost]
        [Route("id")]
        public async Task<IActionResult> GetClienteByUUID([FromBody]Client client)
        {
            var item = await _clientRepository.getClientByUUID(client.UUID.ToString());

            return item != null ? Ok(item) : (ActionResult)NotFound();
        }
    }
}
