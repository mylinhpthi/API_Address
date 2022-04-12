using API_Address.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class hinhanh
    {
        public ObjectId Id { get; set; }
        public string id_hinhanh { get; set; }
        public string hinhanh_mota { get; set; }
        public string hinhanh_url { get; set; }
        public virtual diadiem diadiem { get; set; }
    }
}
