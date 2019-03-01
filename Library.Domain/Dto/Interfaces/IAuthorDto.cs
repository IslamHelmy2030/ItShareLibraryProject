namespace Library.Domain.Dto.Interfaces
{
    public interface IAuthorDto
    {
        int AuthorId { get; set; }
        string AuthorName { get; set; }
        string GenderName { get; set; }
    }
}
