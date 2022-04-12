using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class cotintuc
    {
        public string id_tintuc { get; set; }
        public string cotintuc_ngay { get; set; }

        public virtual diadiem diadiem { get; set; }
        public virtual tintuc tintuc { get; set; }
    }
}
