using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL
{
    internal class AdministratorRepository
    {
        public void AdministratorCreateManagers(int managerId, string managerName, string? managerGmail, string? managerPhone)
        {
            var manager = new ManagerRepository();
        }
    }
}
