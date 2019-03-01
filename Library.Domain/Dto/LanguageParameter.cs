using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Dto
{
    public class LanguageParameter
    {
        [Required(AllowEmptyStrings = false), StringLength(10, MinimumLength = 3)]
        public string LanguageName { get; set; }
    }
}
