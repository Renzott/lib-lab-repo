using creditos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IList<Client>> getListClient();
        Task<Client> getClientByUUID(string uuid);

    }
}
