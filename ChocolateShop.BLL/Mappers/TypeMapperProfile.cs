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
    public class TypeMapperProfile: Profile
    {
        public TypeMapperProfile()
        {
            CreateMap<TypeDto, TypeOutputModel>();
        }
    }
}
