//using API_Address.Helpers;
//using API_Address.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace API_Address.Services
//{
//    public interface IUserService
//    {
//        AuthenticateResponse Authenticate(string username, string password);
//        IEnumerable<AuthenticateRequest> GetAll();
//        AuthenticateResponse GetById(int id);
//        AuthenticateResponse Create(AuthenticateRequest user, string password);
//        void Update(AuthenticateRequest user, string password = null);
//        void Delete(int id);
//    }

//    public class UserService : IUserService
//    {
//        private readonly IConfiguration _configuration;
//        private readonly MongoClient dbClient;
//        public UserService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//            dbClient = new MongoClient(_configuration.GetConnectionString("AddressAppCon"));

//        }

//        public JsonResult Authenticate(string username, string password)
//        {
//            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//                return null;
//            var filter = Builders<taikhoan>.Filter.Eq("taikhoan_username", username) &
//                Builders<taikhoan>.Filter.Eq("taikhoan_password", password);

//            var res = dbClient.GetDatabase("AddressDB").GetCollection<taikhoan>("TaiKhoan").Find<taikhoan>(filter).ToList();

//            if (res.Count != 0)
//            {
//                return new JsonResult(res);
//            }
//            return new JsonResult("Fail to authentication");
//        }

//        public IEnumerable<AuthenticateRequest> GetAll()
//        {
//            return _context.Users;
//        }

//        public AuthenticateResponse GetById(int id)
//        {
//            return _context.Users.Find(id);
//        }

//        public AuthenticateResponse Create(AuthenticateRequest user, string password)
//        {
//            // validation 
//            if (string.IsNullOrWhiteSpace(password))
//                throw new AppException("Password is required");

//            if (_context.Users.Any(x => x.Username == user.Username))
//                throw new AppException("Username \"" + user.Username + "\" is already taken");

//            byte[] passwordHash, passwordSalt;
//            CreatePasswordHash(password, out passwordHash, out passwordSalt);

//            user.PasswordHash = passwordHash;
//            user.PasswordSalt = passwordSalt;

//            _context.Users.Add(user);
//            _context.SaveChanges();

//            return user;
//        }

//        public void Update(AuthenticateRequest userParam, string password = null)
//        {
//            var user = _context.Users.Find(userParam.Id);

//            if (user == null)
//                throw new AppException("User not found");

//            // update username if it has changed
//            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
//            {
//                // throw error if the new username is already taken
//                if (_context.Users.Any(x => x.Username == userParam.Username))
//                    throw new AppException("Username " + userParam.Username + " is already taken");

//                user.Username = userParam.Username;
//            }

//            // update user properties if provided
//            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
//                user.FirstName = userParam.FirstName;

//            if (!string.IsNullOrWhiteSpace(userParam.LastName))
//                user.LastName = userParam.LastName;

//            // update password if provided
//            if (!string.IsNullOrWhiteSpace(password))
//            {
//                byte[] passwordHash, passwordSalt;
//                CreatePasswordHash(password, out passwordHash, out passwordSalt);

//                user.PasswordHash = passwordHash;
//                user.PasswordSalt = passwordSalt;
//            }

//            _context.Users.Update(user);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            var user = _context.Users.Find(id);
//            if (user != null)
//            {
//                _context.Users.Remove(user);
//                _context.SaveChanges();
//            }
//        }

//        // private helper methods

//        //private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//        //{
//        //    if (password == null) throw new ArgumentNullException("password");
//        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

//        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
//        //    {
//        //        passwordSalt = hmac.Key;
//        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//        //    }
//        //}

//        //private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
//        //{
//        //    if (password == null) throw new ArgumentNullException("password");
//        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
//        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
//        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

//        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
//        //    {
//        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//        //        for (int i = 0; i < computedHash.Length; i++)
//        //        {
//        //            if (computedHash[i] != storedHash[i]) return false;
//        //        }
//        //    }

//        //    return true;
//        //}
//    }
//}
