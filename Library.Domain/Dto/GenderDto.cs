using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Library.Domain.Dto.Interfaces;

namespace Library.Domain.Dto
{
    public class GenderDto : IGenderDto
    {
        [Required(ErrorMessage = "Something went wrong, please try again")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "Gender Type is required")]
        [StringLength(maximumLength:10,MinimumLength = 4,ErrorMessage = "Invaild Length")]
        public string GenderType { get; set; }
    }
}
