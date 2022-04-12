using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class danhgia
    {
        public string id_danhgia { get; set; }
        public string danhgia_sao { get; set; }
        public virtual taikhoan taikhoan { get; set; }
    }
}
