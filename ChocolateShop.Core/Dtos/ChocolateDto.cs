using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.Core.Dtos
{
    public class ChocolateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string StorageTime { get; set; }
        public int Weight { get; set; }
        public CompanyDto Company {  get; set; }
        public TypeDto Type { get; set; }
        public List<AdditiveDto> Additives { get; set; }

    }
}
