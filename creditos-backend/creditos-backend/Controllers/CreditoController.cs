using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creditos_backend.Models;
using creditos_backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace creditos_backend.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICreditoRepository _creditoRepository;
        public CreditoController(ICreditoRepository creditoRepository)
        {
            _creditoRepository = creditoRepository;
        }
         
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetCredits()
        {
            var item = await _creditoRepository.getListCredits();

            return item != null ? Ok(item) : (ActionResult)NotFound();
        }

        [HttpGet]
        [Route("estado")]
        public async Task<ActionResult> GetCreditsByEstado(int estado)
        {
            var item = await _creditoRepository.getListCreditsByEstado(estado);

            return item != null ? Ok(item) : (ActionResult)NotFound();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> SetCredito([FromBody] Credit credit)
        {
            var result = await _creditoRepository.setCredito(credit);
            return result != 0 ? Ok() : ValidationProblem();
        }

        [HttpPost]
        [Route("estado")]
        public async Task<ActionResult> setEstadoCredit([FromBody] Credit credit)
        {
            var result = await _creditoRepository.setEstadoCredit(credit);
            return result != 0 ? Ok() : ValidationProblem();
        }

        [HttpGet]
        [Route("detalle")]
        public async Task<ActionResult> getDetalleCredit([FromForm]int id)
        {
            var item = await _creditoRepository.getDetailsCredit(id);

            return item != null ? Ok(item) : (ActionResult)NotFound();
        }

    }
}
