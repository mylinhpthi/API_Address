using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Models
{
    public class taikhoan
    {
        public ObjectId Id { get; set; }

        [Key]
        public int id_taikhoan { get; set; }

        [Required]
        [MaxLength(50)]
        public string taikhoan_username { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string taikhoan_password { get; set; }

        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b")]
        public string taikhoan_sdt { get; set; }

        [EmailAddress]
        [MaxLength(254)]
        public string taikhoan_email { get; set; }

        [MaxLength(254)]
        public string taikhoan_diachi { get; set; }

        [MaxLength(254)]
        public string taikhoan_hoten { get; set; }

        public int id_tttaikhoan { get; set; }

    }
}
