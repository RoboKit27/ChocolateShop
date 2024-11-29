using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class ChocolateQueries
    {
        public const string GetAllChocolatesQuery = "SELECT \"Id\", \"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\", \"CompanyId\", \"TypeId\" FROM public.\"Chocolate\";";
        public const string GetChocolateByIdQuery = "SELECT \"Id\", \"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\", \"CompanyId\", \"TypeId\" FROM public.\"Chocolate\" where \"Id\"=@Id;";
        public const string AddChocolate = "INSERT INTO \"Chocolate\"(\"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\", \"CompanyId\", \"TypeId\") VALUES (@Name, @Cost, @ProductDate, @BestBefore, @Weight, @CompanyId, @TypeId);";
    }
}
