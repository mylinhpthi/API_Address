using API_Address.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<diadiem> _diadiems;
        private const string DatabaseConnect = "AddressAppCon";
        private const string DatabaseName = "AddressDB";
        private const string DatabaseCollection = "diadiem";
        private readonly IConfiguration _configuration;
        private readonly string key;
        public AddressService(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetConnectionString(DatabaseConnect));
            var database = client.GetDatabase(DatabaseName);
            _diadiems = database.GetCollection<diadiem>(DatabaseCollection);
            this.key = _configuration.GetSection("JwtKey").ToString();
        }

        public List<diadiem> Get() =>
            _diadiems.Find(diadiem => true).ToList();

        public diadiem Get(string id) =>
            _diadiems.Find<diadiem>(tk => tk.id_diadiem == id).FirstOrDefault();

        public diadiem Create(diadiem diadiem)
        {
            _diadiems.InsertOne(diadiem);
            return diadiem;
        }

        public void Update(string id, diadiem diadiemIn) =>
            _diadiems.ReplaceOne(tk => tk.id_diadiem == id, diadiemIn);

        public void Remove(diadiem diadiemIn) =>
            _diadiems.DeleteOne(diadiem => diadiem.id_diadiem == diadiemIn.id_diadiem);

        public void Remove(string id) =>
            _diadiems.DeleteOne(tk => tk.id_diadiem == id);

        
    }
}
