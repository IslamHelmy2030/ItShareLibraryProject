using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.Entities;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto.Interfaces;
using Library.Domain.Dto.Parameters;
using Library.Repositories.UnitOfWork;

namespace Library.Domain.Business
{
    public class AuthorBusiness : BusinessBase<Author>, IAuthorBusiness
    {
        public AuthorBusiness(IUnitOfWork<Author> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAuthor(AddAuthorParameter author)
        {
            var authorEntit = Mapper.Map<AddAuthorParameter, Author>(author);
            UnitOfWork.Repo.Add(authorEntit);
            var result = await UnitOfWork.SaveChanges();
            return result > 0;
        }

        public async Task<IList<IAuthorDto>> GetAllAuthors()
        {
            var authors = await UnitOfWork.Repo.GetAll(x => x.Gender);
            var authorDtos = Mapper.Map<IList<Author>, IList<IAuthorDto>>(authors);
            return authorDtos;
        }

        public async Task<IAuthorDto> GetAuthor(int authorId)
        {
            var author = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == authorId, c => c.Gender);
            var authorDto = Mapper.Map<Author, IAuthorDto>(author);
            return authorDto;
        }

        public async Task<bool> UpdateAuthor(UpdateAuthorParameter author)
        {
            var authorEntity = Mapper.Map<UpdateAuthorParameter, Author>(author);
            UnitOfWork.Repo.Update(authorEntity);
            var result = await UnitOfWork.SaveChanges();
            return result > 0;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            var result = await UnitOfWork.SaveChanges();
            return result > 0;
        }
    }
}
