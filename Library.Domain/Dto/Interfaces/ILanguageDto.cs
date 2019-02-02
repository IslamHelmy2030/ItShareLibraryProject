using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Dto.Interfaces
{
    public interface ILanguageDto
    {
        int LanguageId { get; set; }
        string LanguageName { get; set; }
    }
}
