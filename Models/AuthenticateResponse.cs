using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(taikhoan tk, string token)
        {
            Id = tk.id_taikhoan;
            HoTen = tk.taikhoan_hoten;
            Username = tk.taikhoan_username;
            Token = token;
        }
    }
}
