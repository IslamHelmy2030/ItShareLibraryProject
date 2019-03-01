using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Dto.Interfaces;

namespace Library.Domain.Dto
{
    public class LanguageDto : LanguageParameter, ILanguageDto
    {
        public int LanguageId { get; set; }
    }
}
