using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.Entities;
using Library.Domain.Business.Interfaces;
using Library.Repositories.UnitOfWork;

namespace Library.Domain.Business
{
    public class BusinessBase<T> where T : class
    {
        protected readonly IUnitOfWork<T> UnitOfWork;
        protected readonly IMapper Mapper;

        public BusinessBase(IUnitOfWork<T> unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
