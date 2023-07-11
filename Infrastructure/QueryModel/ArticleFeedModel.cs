namespace Infrastructure.QueryModel;

public class ArticleFeedModel
{
    public int ArticleId { get; set; }
    public string? Headline { get; set; }
    public string? ArticleImgUrl { get; set; }
    public string? Body { get; set; }
}