﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class ClientQueries
    {
        public const string GetAllClientsQuery = "select \"Id\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"Email\" from \"Client\";";
        public const string GetClientByIdQuery = "select \"Id\", \"FirstName\", \"LastName\", \"Phone\", \"Password\", \"Email\" from \"Client\" where \"Id\"=@Id;";

        public const string AddClientQuery = "insert into \"Client\"(\"FirstName\",\"LastName\",\"Phone\",\"Password\",\"Email\") values(@FirstName, @LastName, @Phone, @Password, @Email)";

    }
}
