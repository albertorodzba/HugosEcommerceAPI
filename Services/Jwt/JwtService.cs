using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using hugosEcommerce_api.Utils.Secrets;

namespace hugosEcommerce_api.Services.Jwt;

    public class JwtService: IJwtService
    {
        //VARIABLES 
        
        private string secretKey = EnvironmentVariables.JWTSecret; 
        private int expireTime = 240; //minutes
        private readonly ILogger _logger;

        public JwtService(ILogger<JwtService> logger){
            this._logger = logger;
    }

    public string GenerateToken(int userId, string username, int role){
        _logger.LogDebug("GENERATING TOKEN");
        //security key
        var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));

        //credentials
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //payload info
        List<Claim> claims = new List<Claim>{
            new Claim("id", userId.ToString()),
            new Claim("username", username),
            new Claim("role", role.ToString())
        };
        
        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(expireTime),
            signingCredentials: credentials
        );

        var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(securityToken);

        _logger.LogDebug("Token generated");
        
        return tokenEncoded;
    }


    public string GenerateToken(long userId, string username, int role){
        _logger.LogDebug("GENERATING TOKEN");
        
        //security key
        var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));

        //credentials
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //payload info
        List<Claim> claims = new List<Claim>{
            new Claim("id", userId.ToString()),
            new Claim("username", username),
            new Claim("roleType", role.ToString())
        };
        
        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(expireTime),
            signingCredentials: credentials
        );

        var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(securityToken);

        _logger.LogDebug("Token generated");
        
        return tokenEncoded;
    }

    }
