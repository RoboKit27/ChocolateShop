using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class ChocolateQueries
    {
        public const string GetAllChocolatesQuery = "select CH.\"Id\", CH.\"Name\", CH.\"Cost\", CH.\"StorageTime\", CH.\"Weight\", C.\"Id\", C.\"Name\", C.\"Country\", T.\"Id\", T.\"Name\" from \"Chocolate\" as CH join \"Company\" as C on C.\"Id\"=CH.\"CompanyId\" join \"Type\" as T on T.\"Id\"=CH.\"TypeId\"";
        public const string GetChocolateByIdQuery = "select CH.\"Id\", CH.\"Name\", CH.\"Cost\", CH.\"StorageTime\", CH.\"Weight\", C.\"Id\", C.\"Name\", C.\"Country\", T.\"Id\", T.\"Name\" from \"Chocolate\" as CH join \"Company\" as C on C.\"Id\"=CH.\"CompanyId\" join \"Type\" as T on T.\"Id\"=CH.\"TypeId\" where CH.\"Id\"=@Id;";
        public const string GetChocolateAdditivesByChocolateIdQuery = "select A.\"Id\", A.\"Name\" from \"Additive\" as A join \"Chocolate_Additive\" as CA on CA.\"AdditiveId\"=A.\"Id\" join \"Chocolate\" as CH on CH.\"Id\"=CA.\"ChocolateId\" where CA.\"ChocolateId\"=@Id";
        public const string GetChocolateCompanyByChocolateIdQuery = "select COM.\"Id\", COM.\"Name\", COM.\"Country\" from \"Company\" as COM join \"Chocolate\" as CH on CH.\"CompanyId\"=COM.\"Id\" where CH.\"Id\"=@Id";
        public const string GetChocolateTypeByChocolateIdQuery = "select T.\"Id\", T.\"Name\" from \"Type\" as T join \"Chocolate\" as CH on CH.\"TypeId\"=T.\"Id\" where CH.\"Id\"=@Id";
        public const string GetAllChocolateCompaniesQuery = "select \"Id\", \"Name\", \"Country\" from \"Company\";";
        public const string GetAllChocolateTypesQuery = "select \"Id\", \"Name\" from \"Type\";";

        public const string AddChocolateQuery = "insert into \"Chocolate\"(\"Name\", \"Cost\", \"StorageTime\", \"Weight\", \"CompanyId\", \"TypeId\") values (@Name, @Cost, @StorageTime, @Weight, @CompanyId, @TypeId) returning \"Id\";";
        public const string AddChocolateAdditivesQuery = "insert into \"Chocolate_Additive\"(\"ChocolateId\",\"AdditiveId\") values (@ChocolateId,@AdditiveId)";
    }
}
