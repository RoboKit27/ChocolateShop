using AutoMapper;
using ChocolateShop.Core.Dtos;
using ChocolateShop.Core.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.BLL.Mappers
{
    public class ChocolateMapperProfile : Profile
    {
        public ChocolateMapperProfile()
        {
            CreateMap<ChocolateDto, ChocolateOutputModel>().ForMember(
            dist=>dist.CompanyName, opt=>opt.MapFrom(c=>c.Company.Name));
        }
    }
}
