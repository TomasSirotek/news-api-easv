using Dapper;
using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;
using Npgsql;

namespace Infrastructure.Repository;

public class ArticleRepository : IArticleRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public ArticleRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<ArticleQueryModel> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize)
    {
        using var connection = _dataSource.OpenConnection();

        var sql = @"SELECT article_id AS ArticleId, author, headline
                FROM news.articles
                WHERE headline ILIKE '%' || @searchDtoSearchTerm || '%'
                LIMIT @searchDtoPageSize";
        
        return connection.Query<ArticleQueryModel>(sql, new {searchDtoSearchTerm, searchDtoPageSize});
    }

    public IEnumerable<ArticleFeedModel> GetAllArticlesForFeed()
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "SELECT article_id AS ArticleId,headline, article_img_url AS ArticleImgUrl, body FROM news.articles";
        
        return connection.Query<ArticleFeedModel>(sql);
    }
    
    public Article GetArticleById(int articleId)
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "SELECT article_id AS ArticleId,author, headline, article_img_url AS ArticleImgUrl, body FROM news.articles WHERE article_id = @articleId";
        return connection.QueryFirst<Article>(sql, new {articleId});
    }
    
    public Article CreateArticle(string headline, string author, string articleImgUrl,
        string articleBody)
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "INSERT INTO news.articles (headline, author, article_img_url, body) VALUES (@headline, @author, @articleImgUrl, @articleBody) RETURNING article_id as ArticleId, headline, author, article_img_url as ArticleImgUrl, body";
        return connection.QueryFirst<Article>(sql, new {headline, author, articleImgUrl, articleBody});
    }
    
    public Article UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor,
        string articleDtoArticleImgUrl, string articleDtoBody)
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "UPDATE news.articles SET headline = @articleDtoHeadline, author = @articleDtoAuthor, article_img_url = @articleDtoArticleImgUrl, body = @articleDtoBody WHERE article_id = @articleDtoArticleId RETURNING article_id as ArticleId, headline, author, article_img_url as ArticleImgUrl, body";
        return connection.QueryFirst<Article>(sql, new {articleDtoArticleId, articleDtoHeadline, articleDtoAuthor, articleDtoArticleImgUrl, articleDtoBody});
    }
    
    public bool DeleteArticleById(int articleId)
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "DELETE FROM news.articles WHERE article_id = @articleId";
        return connection.Execute(sql, new {articleId}) > 0;
    }
}