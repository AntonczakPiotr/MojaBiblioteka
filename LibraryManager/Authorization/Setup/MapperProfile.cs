using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;
using AutoMapper;
using DAL.Models.EntityModels;

namespace Authorization.Setup
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationModel, Users>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Login));
        }
    }
}
