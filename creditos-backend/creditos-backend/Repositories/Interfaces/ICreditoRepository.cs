using creditos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Repositories.Interfaces
{
    public interface ICreditoRepository
    {

        Task<IList<Credit>> getListCredits();
        Task<IList<Credit>> getListCreditsByEstado(int estado);
        Task<int> setCredito(Credit credit);
        Task<int> setEstadoCredit(Credit credit);
        Task<Credit> getDetailsCredit(int id);

    }
}
