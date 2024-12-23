using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    internal class UserQueries
    {
        public const string AddUserQuery = "insert into \"User\"(\"Id\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"RoleId\") values(@Name, @Phone)";
        public const string GetAllUsersQuery = "select \"Id\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"Role\" from \"User\";";
        public const string GetUserByIdQuery = "select \"Id\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"Role\" from \"User\" where \"Id\"=@Id;";
        public const string GetRoleQuery = "select \"Id\", \"RoleId\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"Id\" \"Name\" from \"User\"";
    }
}
