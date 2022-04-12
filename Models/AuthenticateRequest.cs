using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string taikhoan_username { get; set; }

        [Required]
        public string taikhoan_password { get; set; }
    }
}
