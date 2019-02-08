using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.Entities;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;
using Library.Repositories.UnitOfWork;

namespace Library.Domain.Business
{
    public class LanguageBusiness : BusinessBase<Language>, ILanguageBusiness
    {
        public LanguageBusiness(IUnitOfWork<Language> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IList<ILanguageDto>> GetAllLanguages()
        {
            var languages = await UnitOfWork.Repo.GetAll();
            var languagesDto = Mapper.Map<IList<Language>, IList<ILanguageDto>>(languages);
            return languagesDto;
        }

        public async Task<ILanguageDto> GetLanguage(int languageId)
        {
            var language = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == languageId);
            var languagesDto = Mapper.Map<Language, ILanguageDto>(language);
            return languagesDto;
        }

        public async Task<bool> AddLanguage(LanguageParameter languageParameter)
        {
            var language = Mapper.Map<LanguageParameter, Language>(languageParameter);
            UnitOfWork.Repo.Add(language);
            bool isSaved = await UnitOfWork.SaveChanges() > 0;
            return isSaved;
        }

        public async Task<bool> UpdateLanguage(LanguageDto languageDto)
        {
            var language = Mapper.Map<LanguageDto, Language>(languageDto);
            UnitOfWork.Repo.Update(language);
            bool isSaved = await UnitOfWork.SaveChanges() > 0;
            return isSaved;
        }

        public async Task<bool> DeleteLanguage(int languageId)
        {
            UnitOfWork.Repo.Remove(x=>x.Id == languageId);
            bool isSaved = await UnitOfWork.SaveChanges() > 0;
            return isSaved;
        }

    }

   
}
