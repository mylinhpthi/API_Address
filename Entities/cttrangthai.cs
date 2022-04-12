using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class cttrangthai
    {
        public Nullable<System.DateTime> cttrangthai_thoigian { get; set; }

        public virtual diadiem diadiem { get; set; }
        public virtual ttdiadiem ttdiadiem { get; set; }
    }
}
