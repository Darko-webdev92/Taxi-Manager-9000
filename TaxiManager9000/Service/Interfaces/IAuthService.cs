using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager9000.Service.Interfaces
{
    public interface IAuthService
    {
        bool ChangePassword(string username, string password);  
    }
}
