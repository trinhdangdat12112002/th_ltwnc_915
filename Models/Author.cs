using System.ComponentModel.DataAnnotations;

public class Author
{
    [Required(ErrorMessage = "Nhap de")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nhap FirstName de")]
    public string? sFirstName { get; set; }
    [Required(ErrorMessage = "Nhap LastName de")]
    public string? sLastName { get; set; }
}