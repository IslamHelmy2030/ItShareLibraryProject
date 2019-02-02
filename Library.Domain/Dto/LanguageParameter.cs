using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;

namespace Library.Domain.Dto
{
    public class LanguageParameter : ILanguageParameter
    {
        public string LanguageName { get; set; }
    }
}
