using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class binhluan
    {
        public string id_binhluan { get; set; }
        public string binhluan_noidung { get; set; }
        public Nullable<System.DateTime> binhluan_thoigian { get; set; }

        public virtual diadiem diadiem { get; set; }
        public virtual taikhoan taikhoan { get; set; }
    }
}
