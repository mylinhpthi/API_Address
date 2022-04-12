using API_Address.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Models
{
    public class diadiem
    {
        public diadiem()
        {
            this.binhluans = new HashSet<binhluan>();
            this.cotintucs = new HashSet<cotintuc>();
            this.ctdiadiems = new HashSet<ctdiadiem>();
            this.cttrangthais = new HashSet<cttrangthai>();
            this.hinhanhs = new HashSet<hinhanh>();
            this.khuyenmais = new HashSet<khuyenmai>();
            this.khoes = new HashSet<kho>();
        }

        public ObjectId Id { get; set; }
        public string id_diadiem { get; set; }
        public string diadiem_ten { get; set; }
        public Nullable<double> diadiem_kinhdo { get; set; }
        public Nullable<double> diadiem_vido { get; set; }
        public string diadiem_url { get; set; }
        public string diadiem_mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<binhluan> binhluans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotintuc> cotintucs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctdiadiem> ctdiadiems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cttrangthai> cttrangthais { get; set; }
        public virtual ICollection<danhgia> danhgia { get; set; }
        public virtual danhmuc danhmuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hinhanh> hinhanhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<khuyenmai> khuyenmais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kho> khoes { get; set; }  

    }
}
