using API_Address.Entities;
using API_Address.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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
        //Category
        [HttpGet("/api/Category")]
        public JsonResult ListCategory()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var dbList = dbClient.GetDatabase("AddressDB").GetCollection<danhmuc>("danhmuc").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpGet("/api/Category/{id}")]
        public JsonResult GetCategory(string id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var dbList = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").Find<diadiem>(p=>p.danhmuc.id_danhmuc == id).ToList();
            
            return new JsonResult(dbList);
        }
        //Address
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
            for (int i=0;i<= Lastid_diadiem; i++)
            {
                var diadiem = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").Find<diadiem>(p => p.id_diadiem == i.ToString()).FirstOrDefault();

                if (diadiem == null)
                {
                    tk.id_diadiem = i.ToString();
                    break;
                }
            }
            dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").InsertOne(tk);

            return new JsonResult("Add Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Edit_Addr(diadiem tk)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var diadiem = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").Find<diadiem>(p => p.id_diadiem == tk.id_diadiem).FirstOrDefault();

            if (diadiem == null)
            {
                return NotFound();
            }
            tk.Id = diadiem.Id;
            dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").ReplaceOne(p => p.id_diadiem == tk.id_diadiem, tk);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Del_Addr(String id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<diadiem>.Filter.Eq("id_diadiem", id);
            //var diadiem = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").Find<diadiem>(p => p.id_diadiem == id_diadiem).FirstOrDefault();

            //if (diadiem == null)
            //{
            //    return NotFound();
            //}

            dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
        [HttpGet("{id}")]
        public JsonResult Get_Address(String id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

            var filter = Builders<diadiem>.Filter.Eq("id_diadiem", id);

            var addr = dbClient.GetDatabase("AddressDB").GetCollection<diadiem>("diadiem").Find(filter).FirstOrDefault();

            return new JsonResult(addr);
        }
    }
}
