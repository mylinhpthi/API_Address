using API_Address.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class danhmuc
    {
        public ObjectId Id { get; set; }
        public string id_danhmuc { get; set; }
        public string danhmuc_ten { get; set; }
    }
}
