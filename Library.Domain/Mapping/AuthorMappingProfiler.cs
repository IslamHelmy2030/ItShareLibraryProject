using Library.Data.Entities;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;

namespace Library.Domain.Mapping
{
    public partial class AutoMapperProfiler
    {
        private void AuthorMapping()
        {
            CreateMap<Author, IAuthorDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name))
                .ReverseMap();

            CreateMap<AddAuthorParameter, Author>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.AuthorGenderId));

            CreateMap<UpdateAuthorParameter, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.AuthorGenderId));
        }
    }
}
