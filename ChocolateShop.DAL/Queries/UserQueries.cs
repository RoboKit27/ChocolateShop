using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    internal class UserQueries
    {
        public const string AddUserQuery = "insert into \"User\"(\"Id\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"RoleId\") values(@Id, @FirstName, @LastName, @Phone, @Password, @RoleId)";
        public const string GetAllUsersQuery = "select U.\"Id\", U.\"FirstName\", U.\"LastName\", U.\"Phone\", U.\"Password\", R.\"RoleId\" from \"User\" as U join \"Role\" as R on R.\"RoleId\"=U.\"RoleId\";";
        public const string GetUserByIdQuery = "select U.\"Id\", U.\"FirstName\", U.\"LastName\", U.\"Phone\", U.\"Password\", R.\"RoleId\" from \"User\" as U join \"Role\" as R on R.\"RoleId\"=U.\"RoleId\" where \"Id\"=@Id;";
    }
}
