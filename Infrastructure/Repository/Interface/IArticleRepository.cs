using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Infrastructure.Repository.Interface;

public interface IArticleRepository
{
    IEnumerable<ArticleQueryModel> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize);
    IEnumerable<ArticleFeedModel> GetAllArticlesForFeed();
    Article CreateArticle(string headline, string author, string articleImgUrl, string articleBody);
    Article GetArticleById(int articleId);
    bool DeleteArticleById(int articleId);
    Article UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor, string articleDtoArticleImgUrl, string articleDtoBody);
}