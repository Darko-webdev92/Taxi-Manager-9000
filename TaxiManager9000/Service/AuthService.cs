using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.Models;
using TaxiManager9000.Models.Enums;
using TaxiManager9000.Service.Interfaces;

namespace TaxiManager9000.Service
{
    public static class AuthService
    {
        public static bool Login(string username, string password)
        {
            var user = StaticDb.users.Any(u => u.Username == username && u.Password == password);
            if (user)
            {
                return true;
            }
            return false;
        }

        public static bool Register(string username, string passsword, string role)
        {
            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Please enter valid username");
                return false;
            }
            else if (string.IsNullOrEmpty(passsword))
            {
                Console.WriteLine("Please enter valid username");
                return false;
            }
            if (username.Length < 5)
            {
                return false;
                Console.WriteLine("The username must contain at least 5 characters ");

            }
            if (passsword.Length < 5 && passsword.Any(char.IsDigit))
            {
                Console.WriteLine("The password must contain at least 5 characters and 1 number ");
                return false;
            }
            int Userole;
            bool success = int.TryParse(role, out Userole);
            if (!success)
            {
                Console.WriteLine("Enter valid role");
                return false;
            }
            if (Userole > 3)
            {
                Console.WriteLine("Role must be between 1 and 3");
                return false;
            }
            User user = new User
            {
                Id = ++StaticDb.UserId,
                Username = username,
                Password = passsword,
                Role = (Role)Userole
            };
            StaticDb.users.Add(user);
            return true;
        }


        public static bool ChangePassword(string username,string password)
        {
            var res = StaticDb.users.Where(x => x.Username == username).FirstOrDefault();
            if(res == null)
            {
                Console.WriteLine("User is not found");
                return false;
            }
            if (res.Password != password)
            {
                Console.WriteLine("Old password is not correct");
                return false;
            }
            Console.Write("New Password: ");
            string newPasword =  Console.ReadLine();

            if (newPasword.Length < 5 && newPasword.Any(char.IsDigit))
            {
                Console.WriteLine("The password must contain at least 5 characters and 1 number ");
                return false;
            }
            res.Password = newPasword;

            return true;
        }
    }

}
