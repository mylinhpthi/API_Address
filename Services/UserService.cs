using API_Address.Helpers;
using API_Address.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Claims;
namespace API_Address.Services
{
    public class UserService{
        private readonly IMongoCollection<taikhoan> _taikhoans;
        private const string DatabaseConnect = "AddressAppCon";
        private const string DatabaseName = "AddressDB";
        private const string DatabaseCollection = "taikhoan";
        private readonly IConfiguration _configuration;
        private readonly string key;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetConnectionString(DatabaseConnect));
            var database = client.GetDatabase(DatabaseName);
            _taikhoans = database.GetCollection<taikhoan>(DatabaseCollection);
            this.key = _configuration.GetSection("JwtKey").ToString();
        }

        public List<taikhoan> Get() =>
            _taikhoans.Find(taikhoan => true).ToList();

        public taikhoan Get(int id) =>
            _taikhoans.Find<taikhoan>(tk => tk.id_taikhoan == id).FirstOrDefault();

        public taikhoan Create(taikhoan taikhoan)
        {
            _taikhoans.InsertOne(taikhoan);
            return taikhoan;
        }

        public void Update(int id, taikhoan taikhoanIn) =>
            _taikhoans.ReplaceOne(tk => tk.id_taikhoan == id, taikhoanIn);

        public void Remove(taikhoan taikhoanIn) =>
            _taikhoans.DeleteOne(taikhoan => taikhoan.Id == taikhoanIn.Id);

        public void Remove(int id) =>
            _taikhoans.DeleteOne(tk => tk.id_taikhoan == id);

        public string Authentication(string username, string password)
        {
            var user = this._taikhoans.Find(x => x.taikhoan_username == username && x.taikhoan_password == password).FirstOrDefault();
            if (user == null)
                return null;

            var tokenHandle = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandle.CreateToken(tokenDescriptor);
            return tokenHandle.WriteToken(token);
        }
    }
}
