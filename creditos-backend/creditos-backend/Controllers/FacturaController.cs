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
    public class FacturaController : ControllerBase
    {

        private readonly IFacturaRepository _facturaRepository;

        public FacturaController(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetListFacturas()
        {
            var item = await _facturaRepository.getListFacturas();

            return item != null ? Ok(item) : (ActionResult)NotFound();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> SetFactura([FromBody] Factura factura)
        {
            var result = await _facturaRepository.setFactura(factura);

            return result != 0 ? Ok() : ValidationProblem();
        }

        [HttpPost]
        [Route("estado")]
        public async Task<ActionResult> SetFacturaEstado([FromBody] Factura factura)
        {
            var result = await _facturaRepository.setEstadoFactura(factura);

            return result != 0 ? Ok() : ValidationProblem();
        }
        
        [HttpPost]
        [Route("observacion")]
        public async Task<ActionResult> SetFacturaObservacion([FromBody]Factura factura)
        {
            var result = await _facturaRepository.setObsevacionesFactura(factura);

            return result != 0 ? Ok() : ValidationProblem();
        }

    }
}
