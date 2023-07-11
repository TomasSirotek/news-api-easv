using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;
using Service.Service.Interface;

namespace Service.Service;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<IEnumerable<ArticleQueryModel>> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize)
    {
       return await _articleRepository.SearchArticles(searchDtoSearchTerm, searchDtoPageSize);
    }

    public async Task<IEnumerable<ArticleFeedModel>> GetAllArticlesForFeed()
    {
        return await _articleRepository.GetAllArticlesForFeed();
    }
    
    public async Task<Article> GetArticleById(int articleId)
    {
        return await _articleRepository.GetArticleById(articleId);
    }
    public async Task<Article> CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl,
        string articleRequestBody)
    {
       return await _articleRepository.CreateArticle(articleRequestHeadline, articleRequestAuthor, articleRequestArticleImgUrl, articleRequestBody);
    }

    public async Task<Article> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor,
        string articleDtoArticleImgUrl, string articleDtoBody)
    {
        return await _articleRepository.UpdateArticle(articleDtoArticleId, articleDtoHeadline, articleDtoAuthor, articleDtoArticleImgUrl, articleDtoBody);
    }
    public async Task<bool> DeleteArticleById(int articleId)
    {
        return await _articleRepository.DeleteArticleById(articleId);
    }
}