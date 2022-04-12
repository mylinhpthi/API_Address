using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class quyvip
    {
        public string id_quyvip { get; set; }
        public Nullable<float> quyvip_giatri { get; set; }
        public string id_taikhoan { get; set; }

        public virtual taikhoan taikhoan { get; set; }
    }
}
