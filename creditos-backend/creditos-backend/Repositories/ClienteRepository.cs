using creditos_backend.Models;
using creditos_backend.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Repositories
{
    public class ClienteRepository : IClientRepository
    {

        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection MySQLConnection
        {
            get
            {
                return new MySqlConnection(_configuration.GetConnectionString("mySQL"));
            }
        }

        public async Task<Client> getClientByUUID(string uuid)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "select * from tb_client where UUID = @uuid";

                var result = await conn.QueryAsync<Client>(query, new { uuid });

                return result.FirstOrDefault();
            }
        }

        public async Task<IList<Client>> getListClient()
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "select * from tb_client";

                var result = await conn.QueryAsync<Client>(query);

                return result.ToList();
            }
        }
    }
}
