using creditos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindUserByMail(string mail);
        Task<User> FindUserByMailPwd(string mail,string pwd);
    }
}
