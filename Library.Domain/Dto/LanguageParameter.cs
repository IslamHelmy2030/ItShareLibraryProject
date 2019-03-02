using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Dto
{
    public class LanguageParameter
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Language Name is required"),
         StringLength(10, MinimumLength = 3,ErrorMessage = "Language name length is invalid")]
        public string LanguageName { get; set; }
    }
}
