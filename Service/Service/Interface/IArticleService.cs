using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Service.Service.Interface;

public interface IArticleService
{
    Task<IEnumerable<ArticleQueryModel>> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize);
    Task<IEnumerable<ArticleFeedModel>> GetAllArticlesForFeed();
    Task<Article> GetArticleById(int articleId);
    Task<Article> CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl, string articleRequestBody);
    Task<Article> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor, string articleDtoArticleImgUrl, string articleDtoBody);
    Task<bool> DeleteArticleById(int articleId);
}