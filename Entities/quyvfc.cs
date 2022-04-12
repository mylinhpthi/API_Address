using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class quyvfc
    {
        public string id_quyvfc { get; set; }
        public Nullable<float> quyvfc_giatri { get; set; }
        public string id_taikhoan { get; set; }

        public virtual taikhoan taikhoan { get; set; }
    }
}
