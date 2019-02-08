using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.Entities;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;
using Library.Repositories.UnitOfWork;

namespace Library.Domain.Business
{
    public class GenderBusiness : BusinessBase<Gender>, IGenderBusiness
    {
        public GenderBusiness(IUnitOfWork<Gender> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IList<IGenderDto>> GetAllGenders()
        {
            var result = await UnitOfWork.Repo.GetAll();
            var resultDto = Mapper.Map<IList<Gender>, IList<IGenderDto>>(result);
            return resultDto;
        }

        public async Task<IGenderDto> GetGender(int genderId)
        {
            var gender = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == genderId);
            var genderDto = Mapper.Map<Gender, IGenderDto>(gender);
            return genderDto;
        }

        public async Task<bool> AddGender(GenderParameter genderParameter)
        {
            var gender = Mapper.Map<GenderParameter, Gender>(genderParameter);
            UnitOfWork.Repo.Add(gender);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateGender(GenderDto genderDto)
        {
            var gender = Mapper.Map<GenderDto, Gender>(genderDto);
            UnitOfWork.Repo.Update(gender);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteGender(int id)
        {
            UnitOfWork.Repo.Remove(x=>x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
