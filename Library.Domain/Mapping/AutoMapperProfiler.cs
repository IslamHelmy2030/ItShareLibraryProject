using AutoMapper;

namespace Library.Domain.Mapping
{
    public partial class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            GenderMapping();
            LanguageMapping();
            AuthorMapping();
        }
    }
}
