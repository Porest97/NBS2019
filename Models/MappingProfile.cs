using AutoMapper;
using NBS2019.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>();


        }
    }
}
