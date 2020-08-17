using creditos_backend.Models;
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
    public class UserRepository : IUserRepository
    {

        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
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

        public async Task<User> FindUserByMail(string mail)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "Select * from tb_user where mail = @MAIL";
                conn.Open();

                var result = await conn.QueryAsync<User>(query, new { MAIL = mail });

                return result.FirstOrDefault();
            }
        }

        public async Task<User> FindUserByMailPwd(string mail, string pwd)
        {
            using (IDbConnection conn = MySQLConnection)
            {
                string query = "Select * from tb_user where mail = @mail and password = @pwd";
                conn.Open();

                var result = await conn.QueryAsync<User>(query, new { mail, pwd });

                return result.FirstOrDefault();
            }
        }

    }
}
