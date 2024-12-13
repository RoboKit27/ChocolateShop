using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class OrderQueries
    {
        public const string GetAllOrdersQuery = "select \"Id\",\"Date\" from \"Order\";";
        public const string GetOrderByIdQuery = "select \"Id\",\"Date\" from \"Order\" where \"Id\"=@Id;";
        public const string GetOrderClientByOrderIdQuery = "select C.\"Id\",C.\"Name\",C.\"Phone\",C.\"Gmail\" from \"Order\" as O join \"Client\" as C on C.\"Id\"=O.\"ClientId\" where O.\"Id\"=@Id";
        public const string GetOrderChocolatesByOrderIdQuery = "select \"ChocolateId\" from \"Order_Chocolate\" where \"OrderId\"=@Id";

        public const string AddOrderQuery = "insert into \"Order\"(\"Date\",\"ClientId\") values(@Date,@ClientId) returning \"Id\";";
        public const string AddOrderChocolatesQuery = "insert into \"Order_Chocolate\"(\"OrderId\",\"ChocolateId\") values(@OrderId,@ChocolateId);";
    }
}
