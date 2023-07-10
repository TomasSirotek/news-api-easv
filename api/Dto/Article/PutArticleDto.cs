using System.ComponentModel.DataAnnotations;
namespace api.Dto.Article;

public class PutArticleDto
{
    // Headline must be between 5 and 30 characters (inclusive)
    //The body can be up to 1000 characters
    // The news media only has 4 journalists: Bob, Rob, Dob, Lob, and the author should be one of these.

    [Required]
    [StringLength(30, MinimumLength = 5)]
    public string? Headline { get; set; }
    
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string? Body { get; set; }
    
    [Required]
    public string? ArticleImgUrl { get; set; }
    
    [Required]
    [RegularExpression("^(Bob|Rob|Dob|Lob)$")]
    public string? Author { get; set; }
}