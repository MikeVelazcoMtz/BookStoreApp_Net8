namespace BookStoreApp.Models;

using System.ComponentModel.DataAnnotations;

public class AuthorCreateDTO
{
    public AuthorCreateDTO()
    {
        if (FirstName == null) {
            FirstName = "";
        }

        if (LastName == null) {
            LastName = "";
        }

        if (Bio == null) {
            Bio = "";
        }
    }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set;}

    [Required]
    [StringLength(50)]
    public string LastName { get; set;}


    [StringLength(250)]
    public string Bio { get; set;}
}