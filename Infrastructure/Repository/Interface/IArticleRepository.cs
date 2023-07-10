using Infrastructure.DataModel;

namespace Infrastructure.Repository.Interface;

public interface IArticleRepository
{
    IEnumerable<Article> GetAllArticles();
    Article CreateArticle(string headline, string author, string articleImgUrl, string articleBody);
}