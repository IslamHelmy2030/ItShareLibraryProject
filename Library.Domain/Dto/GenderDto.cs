using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Dto.Interfaces;

namespace Library.Domain.Dto
{
    public class GenderDto : IGenderDto
    {
        public int Id { get; set; }
        public string GenderType { get; set; }
    }
}
