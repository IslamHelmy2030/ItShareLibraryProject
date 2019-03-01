using Library.Data.Entities;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;

namespace Library.Domain.Mapping
{
    public partial class AutoMapperProfiler
    {
        private void LanguageMapping()
        {
            CreateMap<LanguageDto, Language>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.WrittenLanguage, opt => opt.MapFrom(src => src.LanguageName))
                .ReverseMap();
            CreateMap<Language, ILanguageDto>()
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.WrittenLanguage))
                .ReverseMap();

            CreateMap<LanguageParameter, Language>()
                .ForMember(dest => dest.WrittenLanguage, opt => opt.MapFrom(src => src.LanguageName));
        }
    }
}
