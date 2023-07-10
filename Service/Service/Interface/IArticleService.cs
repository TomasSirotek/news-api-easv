using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Service;

public interface IArticleService
{
    IEnumerable<ArticleQueryModel> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize);
    IEnumerable<ArticleFeedModel> GetAllArticlesForFeed();
    Article GetArticleById(int articleId);
    Article CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl, string articleRequestBody);
    Article UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor, string articleDtoArticleImgUrl, string articleDtoBody);
    bool DeleteArticleById(int articleId);
}