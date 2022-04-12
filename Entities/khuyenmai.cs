using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class khuyenmai
    {
        public string id_khuyenmai { get; set; }
        public string khuyenmai_noidung { get; set; }
        public Nullable<System.DateTime> khuyenmai_ngaybd { get; set; }
        public Nullable<System.DateTime> khuyenmai_ngaykt { get; set; }

        public virtual diadiem diadiem { get; set; }
        public virtual taikhoan taikhoan { get; set; }
    }
}
