using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class kho
    {
        public string id_kho { get; set; }

        public virtual taikhoan taikhoan { get; set; }
    }
}
