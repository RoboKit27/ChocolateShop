using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class ChocolateQueries
    {
        public const string GetAllChocolatesQuery = "select \"Id\", \"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\", \"CompanyId\", \"TypeId\" from \"Chocolate\";";
        public const string GetChocolateByIdQuery = "select \"Id\", \"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\" from \"Chocolate\" where \"Id\"=@Id;";
        public const string GetChocolateAdditives = "select A.\"Id\", A.\"Name\" from \"Additive\" as A join \"Chocolate_Additive\" as CA on CA.\"AdditiveId\"=A.\"Id\" join \"Chocolate\" as CH on CH.\"Id\"=CA.\"ChocolateId\" where CA.\"ChocolateId\"=@Id";
        public const string GetChocolateCompany = "select COM.\"Id\", COM.\"Name\", COM.\"Country\" from \"Company\" as COM join \"Chocolate\" as CH on CH.\"CompanyId\"=COM.\"Id\" where CH.\"Id\"=@Id";
        public const string GetChocolateType = "select T.\"Id\", T.\"Name\" from \"Type\" as T join \"Chocolate\" as CH on CH.\"TypeId\"=T.\"Id\" where CH.\"Id\"=@Id";

        public const string AddChocolate = "insert into \"Chocolate\"(\"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\", \"CompanyId\", \"TypeId\") values (@Name, @Cost, @ProductDate, @BestBefore, @Weight, @CompanyId, @TypeId);";
        public const string AddChocolateAdditives = "insert into \"Chocolate_Additive\"(\"ChocolateId\",\"AdditiveId\") values (@ChocolateId,@AdditiveId)";
    }
}
