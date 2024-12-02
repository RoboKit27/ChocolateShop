using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class ClientQueries
    {
        public const string GetAllClientsQuery = "select \"Id\", \"Name\", \"Phone\", \"Gmail\" from \"Client\";";
        public const string GetClientByIdQuery = "select \"Id\", \"Name\", \"Phone\", \"Gmail\" from \"Client\" where \"Id\"=@Id;";

        public const string AddClientQuery = "insert into \"Client\"(\"Name\",\"Phone\",\"Gmail\") values(@Name, @Phone, @Gmail)";

    }
}
