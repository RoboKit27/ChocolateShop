using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    internal class UserQueries
    {
        public const string AddUserQuery = "insert into \"User\"(\"Name\",\"Phone\") values(@Name, @Phone)";
        public const string GetAllUsersQuery = "select \"Id\", \"Name\", \"Phone\" from \"User\";";
        public const string GetUserByIdQuery = "select \"Id\", \"Name\", \"Phone\" from \"User\" where \"Id\"=@Id;";
    }
}
