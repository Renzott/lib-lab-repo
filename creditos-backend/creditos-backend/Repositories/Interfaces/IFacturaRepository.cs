using creditos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Repositories.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IList<Factura>> getListFacturas();
        Task<Factura> GetFacturaByID(string id);
        Task<int> setFactura(Factura factura);
        Task<int> setEstadoFactura(Factura factura);
        Task<int> setObsevacionesFactura(Factura factura);
    }
}
