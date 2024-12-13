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
        public const string GetChocolateAdditivesByChocolateIdQuery = "select A.\"Id\", A.\"Name\" from \"Additive\" as A join \"Chocolate_Additive\" as CA on CA.\"AdditiveId\"=A.\"Id\" join \"Chocolate\" as CH on CH.\"Id\"=CA.\"ChocolateId\" where CA.\"ChocolateId\"=@Id";
        public const string GetChocolateCompanyByChocolateIdQuery = "select COM.\"Id\", COM.\"Name\", COM.\"Country\" from \"Company\" as COM join \"Chocolate\" as CH on CH.\"CompanyId\"=COM.\"Id\" where CH.\"Id\"=@Id";
        public const string GetChocolateTypeByChocolateIdQuery = "select T.\"Id\", T.\"Name\" from \"Type\" as T join \"Chocolate\" as CH on CH.\"TypeId\"=T.\"Id\" where CH.\"Id\"=@Id";

        public const string AddChocolateQuery = "insert into \"Chocolate\"(\"Name\", \"Cost\", \"ProductDate\", \"BestBefore\", \"Weight\", \"CompanyId\", \"TypeId\") values (@Name, @Cost, @ProductDate, @BestBefore, @Weight, @CompanyId, @TypeId) returning \"Id\";";
        public const string AddChocolateAdditivesQuery = "insert into \"Chocolate_Additive\"(\"ChocolateId\",\"AdditiveId\") values (@ChocolateId,@AdditiveId)";
    }
}
