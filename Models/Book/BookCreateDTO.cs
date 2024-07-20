using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookStoreApp.Models;

public class BookCreateDTO : BaseDTO
{
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }

    [Required]
    [Range(1000, int.MaxValue)]
    public int Year { get; set; }

    [Required]
    public string Isbn { get; set; } = null!;

    [Required]
    [StringLength(250, MinimumLength = 10)]
    public string Summary { get; set; } = null!;

    public string? Image { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    [NotNull]
    public int? AuthorId { get; set; }

}