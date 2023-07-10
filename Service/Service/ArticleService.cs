using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;

namespace Service;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public IEnumerable<ArticleQueryModel> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize)
    {
       return _articleRepository.SearchArticles(searchDtoSearchTerm, searchDtoPageSize);
    }

    public IEnumerable<ArticleFeedModel> GetAllArticlesForFeed()
    {
        return _articleRepository.GetAllArticlesForFeed();
    }
    
    public Article GetArticleById(int articleId)
    {
        return _articleRepository.GetArticleById(articleId);
    }
    public Article CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl,
        string articleRequestBody)
    {
       return _articleRepository.CreateArticle(articleRequestHeadline, articleRequestAuthor, articleRequestArticleImgUrl, articleRequestBody);
    }

    public Article UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor,
        string articleDtoArticleImgUrl, string articleDtoBody)
    {
        return _articleRepository.UpdateArticle(articleDtoArticleId, articleDtoHeadline, articleDtoAuthor, articleDtoArticleImgUrl, articleDtoBody);
    }
    public bool DeleteArticleById(int articleId)
    {
        return _articleRepository.DeleteArticleById(articleId);
    }
}