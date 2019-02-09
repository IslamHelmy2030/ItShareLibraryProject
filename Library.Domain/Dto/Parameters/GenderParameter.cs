using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Dto.Parameters
{
    public class GenderParameter
    {
        [Required(ErrorMessage = "Gender Type Is Required"), StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "Invaild Length")]
        public string GenderType { get; set; }
    }
}
