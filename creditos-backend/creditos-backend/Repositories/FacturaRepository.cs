using creditos_backend.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Repositories.Interfaces
{
    public class FacturaRepository : IFacturaRepository
    {

        private readonly IConfiguration _configuration;

        public FacturaRepository(IConfiguration configuration)
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

        public async Task<IList<Factura>> getListFacturas()
        {
            using (IDbConnection conn = MySQLConnection)
            {

                string query = "select * from tb_factura";
                var result = await conn.QueryAsync<Factura>(query);

                return result.ToList();
            }
        }

        public async Task<Factura> GetFacturaByID(string id)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "select * from tb_factura where id = @id";
                var result = await conn.QueryAsync<Factura>(query, new { id });

                return result.FirstOrDefault();
            }
        }

        public async Task<int> setFactura(Factura factura)
        {
            Factura temporal = factura;

            temporal.id = GenerateIDFactura();

            temporal.fechaEmision = DateTime.Now;
            temporal.estado = 0; // Activo
            temporal.estadoFactura = 0; // Sin Problemas
            temporal.observaciones = "Ninguna";

            using (IDbConnection conn = MySQLConnection)
            {
                string query =
                    "insert into tb_factura values(@id,@import,@igv,@fechaEmision,@fechaVencimiento,@estadoFactura,@estado,@observaciones,@creditoID)";
                var result = await conn.ExecuteAsync(query, temporal);

                return result;
            }
        }

        public async Task<int> setEstadoFactura(Factura factura)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "update tb_factura set estado = @estado where id = @id;";
                var result = await conn.ExecuteAsync(query, factura);

                return result;
            }
        }

        

        public async Task<int> setObsevacionesFactura(Factura factura)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "update tb_factura set observaciones = @observaciones where id = @id;";
                var result = await conn.ExecuteAsync(query, factura);

                return result;
            }
        }

        private string GenerateIDFactura()
        {
            string now = DateTime.Now.ToString("yyyy-MM", CultureInfo.CreateSpecificCulture("es-MX"));

            int countTotalFacturas = getListFacturas().Result.Count();

            string result = "NET-" + now.ToUpper() + "-" +countTotalFacturas.ToString().PadLeft(4, '0');

            return result;
        }
    }
}
