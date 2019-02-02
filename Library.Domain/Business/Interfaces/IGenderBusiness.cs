using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;

namespace Library.Domain.Business.Interfaces
{
    public interface IGenderBusiness
    {
        Task<bool> AddGender(GenderParameter genderParameter);
        Task<IList<IGenderDto>> GetAllGenders();
        Task<IGenderDto> GetGender(int genderId);
        Task<bool> UpdateGender(GenderDto genderDto);
    }
}