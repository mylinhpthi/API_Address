using API_Address.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace API_Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //private readonly AppSettings _appSettings;
        //private string generateJwtToken(taikhoan user)
        //{

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
        [HttpPost("login")]
        public JsonResult Login(AuthenticateRequest model)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<taikhoan>.Filter.Eq("taikhoan_username", model.taikhoan_username) &
                Builders<taikhoan>.Filter.Eq("taikhoan_password", model.taikhoan_password);

            var res = dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").Find<taikhoan>(filter).ToList();

            if (res.Count != 0)
            {
                return new JsonResult(res);
            }
            Response.StatusCode = 404;
            return new JsonResult("Fail to authentication");
        }

        [HttpPost("register")]
        public JsonResult Register(taikhoan tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));
            int Lastid_taikhoan = dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").AsQueryable().Count();
            tk.id_taikhoan = Lastid_taikhoan + 1;

            dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").InsertOne(tk);

            return new JsonResult("Register Successfully");
        }

        [HttpPatch("recovery")]
        public JsonResult Recovery(taikhoan tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<taikhoan>.Filter.Eq("id_taikhoan", tk.id_taikhoan);

            var update = Builders<taikhoan>.Update.Set("taikhoan_password", tk.taikhoan_password);

            dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        //[HttpGet("{id}")]
        //public JsonResult GetById(int id)
        //{
        //    MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

        //    var filter = Builders<taikhoan>.Filter.Eq("id_taikhoan", id);

        //    var tk = dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").Find(filter).ToList();

        //    return new JsonResult(tk);
        //}

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var dbList = dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").AsQueryable();

            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Post(taikhoan tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            int Lastid_taikhoan = dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").AsQueryable().Count();
            tk.id_taikhoan = Lastid_taikhoan + 1;

            dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").InsertOne(tk);

            return new JsonResult("Register Successfully");
        }

        [HttpPut]
        public JsonResult Put(taikhoan tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<taikhoan>.Filter.Eq("id_taikhoan", tk.id_taikhoan);

            var update = Builders<taikhoan>.Update.Set("taikhoan_username", tk.taikhoan_username)
                                                    .Set("taikhoan_password", tk.taikhoan_password)
               .Set("taikhoan_sdt", tk.taikhoan_sdt).Set("taikhoan_diachi", tk.taikhoan_diachi)
               .Set("taikhoan_hoten", tk.taikhoan_hoten).Set("id_tttaikhoan", tk.id_tttaikhoan);
            dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<taikhoan>.Filter.Eq("id_taikhoan", id);


            dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("taikhoan").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
    }
}
