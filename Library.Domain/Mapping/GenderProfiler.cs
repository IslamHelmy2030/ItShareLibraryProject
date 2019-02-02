using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;

namespace Library.Domain.Mapping
{
    public partial class AutoMapperProfiler
    {
        private void GenderMapping()
        {
            CreateMap<Gender, IGenderDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenderType, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<GenderParameter, Gender>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenderType));
        }




    }
}
