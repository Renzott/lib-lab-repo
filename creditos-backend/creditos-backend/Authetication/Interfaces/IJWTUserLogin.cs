﻿using creditos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Authetication.Interfaces
{
    public interface IJWTUserLogin
    {
        string GenerateJSONWebToken(User user);
    }
}
