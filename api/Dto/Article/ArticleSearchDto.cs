using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api.Dto.Article;

public class ArticleSearchDto
{
    [Required(ErrorMessage = "Search term is required")]
    [NotNull]
    [MinLength(3, ErrorMessage = "Search term must be at least 3 characters")]
    public string? SearchTerm { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Page size must be at least 1")]
    public int PageSize { get; set; }
}