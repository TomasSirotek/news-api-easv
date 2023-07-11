using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Infrastructure.Repository.Interface;

public interface IArticleRepository
{
    Task<IEnumerable<ArticleQueryModel>> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize);
    Task<IEnumerable<ArticleFeedModel>> GetAllArticlesForFeed();
    Task<Article> GetArticleById(int articleId);
    Task<Article> CreateArticle(string headline, string author, string articleImgUrl, string articleBody);
    Task<Article> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor, string articleDtoArticleImgUrl, string articleDtoBody);
    Task<bool> DeleteArticleById(int articleId);
}