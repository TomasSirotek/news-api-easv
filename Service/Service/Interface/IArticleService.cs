using Infrastructure.DataModel;

namespace Service;

public interface IArticleService
{
    IEnumerable<Article> GetAllArticles();
    Article CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl, string articleRequestBody);
}