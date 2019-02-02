using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Library.Domain.Mapping
{
    public partial class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            GenderMapping();
            LanguageMapping();
        }
    }
}
