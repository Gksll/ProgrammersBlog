using AutoMapper;
using Entities.Concreate;
using Entities.Concreate.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMapper.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(destinationMember => destinationMember.CreatedDate, memberOptions => memberOptions.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(destinationMember => destinationMember.ModifiedDate, memberOptions => memberOptions.MapFrom(x => DateTime.Now)); ;
        }
    }
}
