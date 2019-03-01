using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Dto;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;

namespace Library.Domain.Business.Interfaces
{
    public interface IAuthorBusiness
    {
        Task<bool> AddAuthor(AddAuthorParameter author);
        Task<IList<IAuthorDto>> GetAllAuthors();
        Task<IAuthorDto> GetAuthor(int authorId);
        Task<bool> UpdateAuthor(UpdateAuthorParameter author);
        Task<bool> DeleteAuthor(int id);
    }
}
