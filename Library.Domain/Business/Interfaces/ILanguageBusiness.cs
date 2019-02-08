using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;

namespace Library.Domain.Business.Interfaces
{
    public interface ILanguageBusiness
    {
        Task<bool> AddLanguage(LanguageParameter languageParameter);
        Task<bool> DeleteLanguage(int languageId);
        Task<IList<ILanguageDto>> GetAllLanguages();
        Task<ILanguageDto> GetLanguage(int languageId);
        Task<bool> UpdateLanguage(LanguageDto languageDto);
    }
}