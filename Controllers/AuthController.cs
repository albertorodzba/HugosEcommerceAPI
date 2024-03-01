
using System.Security.Claims;
using hugosEcommerce_api.Database;
using hugosEcommerce_api.DTOs;
using hugosEcommerce_api.Models;
using hugosEcommerce_api.Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace hugosEcommerce_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IDatabaseConfig _db;

    public AuthController(ILogger<AuthController> logger,
        IJwtService jwtService,
        IPasswordHasher<User> passwordHasher,
        IDatabaseConfig databaseConfig
    )
    {
        _logger = logger;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
        _db = databaseConfig;
    }

    [Authorize(Policy = "Admin")]
    [HttpPost("admin-register")]
    public async Task<IActionResult> AdminRegister([FromBody] UserRegisterDTO userRegisterDTO)
    {
        _logger.LogDebug("registro admins");
        string bearerToken = HttpContext.Request.Headers.Authorization;
        var identity = HttpContext.User.Claims;
        // IEnumerable<Claim> claims = identity.Claims; 
        try
        {
            if (!userRegisterDTO.Password.Equals(userRegisterDTO.passwordConfirmation))
            {
                return new JsonResult(new { success = false, message = "Passwords do not match" });
            }

            if (CheckIfExistsUser(userRegisterDTO.Email, userRegisterDTO.Username))
            {
                return Unauthorized(new { success = false, message = "This account already exists" });
            }
            int role = 1;

            User newUser = new User();
            newUser.Email = userRegisterDTO.Email;
            //encrypt password
            newUser.Password = _passwordHasher.HashPassword(newUser, userRegisterDTO.Password); ;
            newUser.Role = role;
            newUser.Username = userRegisterDTO.Username;

            string query = "INSERT INTO user(email, password, role, username) VALUES (@email, @password, @role, @username)";
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                    new MySqlParameter("@email", newUser.Email),
                    new MySqlParameter("@password", newUser.Password),
                    new MySqlParameter("@role", newUser.Role),
                    new MySqlParameter("@username", newUser.Username)
                };

            _db.OpenConnection();
            _db.MysqlExecuteNonQuery(query, parameters);
            _db.CloseAll();

        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new { success = false, message = "An error occurred" });
        }
        return Ok(new { success = true, message = "User register, Please sign in!" });
    }

    [HttpPost("customer-register")]
    public async Task<IActionResult> CustomerRegister([FromBody] UserRegisterDTO userRegisterDTO)
    {
        try
        {
            if (!userRegisterDTO.Password.Equals(userRegisterDTO.passwordConfirmation))
            {
                return Unauthorized(new { success = false, message = "Passwords do not match" });
            }

            if (CheckIfExistsUser(userRegisterDTO.Email, userRegisterDTO.Username))
            {
                return Unauthorized(new { success = false, message = "This account already exists" });
            }
            int role = 2;

            User newUser = new User();
            newUser.Email = userRegisterDTO.Email;
            //encrypt password
            newUser.Password = _passwordHasher.HashPassword(newUser, userRegisterDTO.Password); ;
            newUser.Role = role;
            newUser.Username = userRegisterDTO.Username;

            string query = "INSERT INTO user(email, password, role, username) VALUES (@email, @password, @role, @username)";
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                    new MySqlParameter("@email", newUser.Email),
                    new MySqlParameter("@password", newUser.Password),
                    new MySqlParameter("@role", newUser.Role),
                    new MySqlParameter("@username", newUser.Username)
                };

            _db.OpenConnection();
            _db.MysqlExecuteNonQuery(query, parameters);
            _db.CloseAll();


        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new { success = false, message = "An error occurred" });
        }
        return Ok(new { success = true, message = "User register, Please sign in!" });
    }


    [HttpPost("signIn")]
    public async Task<IActionResult> SignIn([FromBody] UserLogin userLogin)
    {
        User user = new User();
        string token = "";
        try
        {
            // _logger.LogInformation("correo");
            // _logger.LogInformation(userLogin.Email);
            //COMPRUEBA QUE HAYA LLEGADO CUALQUIERA DE LOS DOS DATOS
            if (
                (userLogin.Email == "" || userLogin.Email == null)
                && (userLogin.Username == "" || userLogin.Username == null)
                && (user.Password == null || user.Password == "")
            )
            {
                return Unauthorized(new { success = false, message = "Credentials are required" });
            }

            //SE PREPARAN LOS PARAMETROS DE MYSQL PARA LA QUERY
            string query = "SELECT * FROM user WHERE email = @email OR username = @username";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                    new MySqlParameter("@email", userLogin.Email),
                    new MySqlParameter("@username", userLogin.Username)
                };

            //lECTURA DE RESULTADO
            _db.OpenConnection();
            var reader = _db.MysqlExecuteQuery(query, parameters);
            while (reader.Read())
            {
                user.PkUser = Convert.ToInt64(reader[0]);
                user.Username = reader[1].ToString();
                user.Email = reader[2].ToString();
                user.Password = reader[3].ToString();
                user.Role = Convert.ToInt32(reader[4]);
            }
            _db.CloseAll();

            /*USUARIO NO ENCONTRADO*/
            if (user.Email == null || user.Username == null)
            {
                return Unauthorized(new { success = false, message = "User not found!" });
            }

            //COMPROBACION DE CONTRASEÑAS
            if (_passwordHasher.VerifyHashedPassword(user, user.Password, userLogin.Password) == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { success = false, message = "Incorrect password" });
            }
            //creacion de token
            token = _jwtService.GenerateToken(user.PkUser, user.Username, (int)user.Role);
        }
        catch
        {
            Console.WriteLine("Exception desde signin controler");
            throw;
            // throw new Exception(ex.ToString());
            return BadRequest(new { success = false, message = "An error occurred, please report this issue" });
        }
        return Ok(new { success = true, message = $"Welcome! {user.Username}", token = token });
    }


    //VERIFICA SI UN USUARIO ESTA REGISTRADO
    public bool CheckIfExistsUser(string email, string username)
    {
        try{
            _logger.LogDebug(username);
            _logger.LogDebug(email);
            string query = "SELECT * FROM user WHERE email = @email OR username = @username";
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@email", email),
                };

            User user = new User();
            _db.OpenConnection();
            var reader = _db.MysqlExecuteQuery(query, parameters);
            while (reader.Read())
            {
                user.PkUser = Convert.ToInt64(reader[0]);
                user.Username = reader[1].ToString();
                user.Email = reader[2].ToString();
                user.Password = reader[3].ToString();
                user.Role = Convert.ToInt32(reader[4]);
            }
            _db.CloseAll();

            //USUARIO NO ENCONTRADO
            if (user.Email == null || user.Username == null)
            {
                return false;
            }

            return true;
        }catch(Exception ex){
            throw;
        }
        
    }

}
