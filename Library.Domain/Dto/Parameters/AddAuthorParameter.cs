using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Dto.Parameters
{
    public class AddAuthorParameter
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Author Name Is Required")]
        [StringLength(10,MinimumLength = 3,ErrorMessage = "Author Name Length Is Invalid")]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int AuthorGenderId { get; set; }
    }
}
