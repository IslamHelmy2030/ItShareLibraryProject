using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;

namespace Library.Domain.Mapping
{
    public partial class AutoMapperProfiler
    {
        private void LanguageMapping()
        {
            CreateMap<Language, ILanguageDto>()
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.WrittenLanguage))
                .ReverseMap();

            CreateMap<LanguageParameter, Language>()
                .ForMember(dest => dest.WrittenLanguage, opt => opt.MapFrom(src => src.LanguageName));
        }
    }
}
