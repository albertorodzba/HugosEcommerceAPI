using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hugosEcommerce_api.Services.Jwt;

    public interface IJwtService
    {
        string GenerateToken(int userId, string username, int role);
        string GenerateToken(long userId, string username, int role);
    }
