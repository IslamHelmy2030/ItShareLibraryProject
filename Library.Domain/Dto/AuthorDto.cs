using Library.Domain.Dto.Interfaces;

namespace Library.Domain.Dto
{
    public class AuthorDto : IAuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string GenderName { get; set; }
    }
}
