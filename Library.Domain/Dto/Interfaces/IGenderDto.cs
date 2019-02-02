using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Dto.Interfaces
{
    public interface IGenderDto
    {
        int Id { get; set; }
        string GenderType { get; set; }
    }
}
