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
    public class CreditoRepository : ICreditoRepository
    {

        private readonly IConfiguration _configuration;

        public CreditoRepository(IConfiguration configuration)
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

        public async Task<IList<Credit>> getListCredits()
        {

            using (IDbConnection conn = MySQLConnection)
            {

                string query = "select * from tb_credito";
                var result = await conn.QueryAsync<Credit>(query);

                return result.ToList();
            }
        }

        public async Task<int> setCredito(Credit credit)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "insert into tb_credito values(default,@clientID,@cantidad,@estado)";
                var result = await conn.ExecuteAsync(query,credit);
                return result;
            }
        }

        public async Task<int> setEstadoCredit(Credit credit)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "update tb_credito set estado = @estado where id = @id;";
                var result = await conn.ExecuteAsync(query, new { estado= credit.Estado, id= credit.ID});
                return result;
            }
        }

        public async Task<Credit> getDetailsCredit(int id)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "Select * from tb_credito where id = @id";
                var result = await conn.QueryAsync<Credit>(query, new { id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IList<Credit>> getListCreditsByEstado(int estado)
        {
            using (IDbConnection conn = MySQLConnection)
            {

                string query = "select * from tb_credito where estado = @estado";
                var result = await conn.QueryAsync<Credit>(query, new { estado});

                return result.ToList();
            }
        }
    }
}
