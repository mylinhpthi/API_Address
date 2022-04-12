using API_Address.Entities;
using API_Address.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IConfiguration _configuration;
        public AddressController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Show_Addr()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var dbList = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").AsQueryable();

            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Add_Addr(diadiem tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            int Lastid_diadiem = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").AsQueryable().Count();
            tk.id_diadiem = (Lastid_diadiem + 1).ToString();

            dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").InsertOne(tk);

            return new JsonResult("Register Successfully");
        }

        [HttpPut]
        public JsonResult Edit_Addr(diadiem tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<diadiem>.Filter.Eq("id_diadiem", tk.id_diadiem);

            var update = Builders<diadiem>.Update.Set("diadiem_ten", tk.diadiem_ten)
                                                    ?.Set("diadiem_kinhdo", tk.diadiem_kinhdo)
               ?.Set("diadiem_vido", tk.diadiem_vido)?.Set("diadiem_url", tk.diadiem_url)?
               .Set("diadiem_mota", tk.diadiem_mota)?.Set("hinhanhs", tk.hinhanhs).Set("danhgia", tk.danhgia);



            dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Del_Addr(string id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<diadiem>.Filter.Eq("id_diadiem", id);


            dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
        [HttpGet("{id}")]
        public JsonResult Get_Address(string id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<diadiem>.Filter.Eq("id_diadiem", id);

            var addr = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").Find(filter).ToList();

            return new JsonResult(addr);
        }
        [HttpGet("image")]
        public JsonResult Show_All_Image()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var dbList = dbClient.GetDatabase("AddressDB").GetCollection<hinhanh>("hinhanh").AsQueryable();

            return new JsonResult(dbList);
        }
    }
}
