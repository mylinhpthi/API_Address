using API_Address.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Entities
{
    public class tttaikhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tttaikhoan()
        {
            this.taikhoans = new HashSet<taikhoan>();
        }

        public string id_tttaikhoan { get; set; }
        public string tttaikhoan_ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taikhoan> taikhoans { get; set; }
    }
}
