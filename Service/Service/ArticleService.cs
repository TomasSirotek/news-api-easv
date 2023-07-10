using Infrastructure.DataModel;
using Infrastructure.Repository.Interface;

namespace Service;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public IEnumerable<Article> GetAllArticles()
    {
        return _articleRepository.GetAllArticles();
    }

    public Article CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl,
        string articleRequestBody)
    {
       return _articleRepository.CreateArticle(articleRequestHeadline, articleRequestAuthor, articleRequestArticleImgUrl, articleRequestBody);
    }
}