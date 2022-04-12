using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class ctdiadiem
    {
        public System.DateTime ctdiadiem_ngaycapnhat { get; set; }
        public string ctdiadiem_tienich { get; set; }
        public string ctdiadiem_dichvu { get; set; }

        public virtual diadiem diadiem { get; set; }
        public virtual taikhoan taikhoan { get; set; }
    }
}
