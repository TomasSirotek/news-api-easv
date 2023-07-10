using Dapper;
using Infrastructure.DataModel;
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

    public IEnumerable<Article> GetAllArticles()
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "SELECT article_id AS ArticleId, headline, article_img_url AS ArticleImgUrl, body FROM news.articles";
        
        return connection.Query<Article>(sql);
    }

    public Article CreateArticle(string headline, string author, string articleImgUrl,
        string articleBody)
    {
        using var connection = _dataSource.OpenConnection();
        var sql = "INSERT INTO news.articles (headline, author, article_img_url, body) VALUES (@headline, @author, @articleImgUrl, @articleBody) RETURNING article_id as ArticleId, headline, author, article_img_url as ArticleImgUrl, body";
        return connection.QueryFirst<Article>(sql, new {headline, author, articleImgUrl, articleBody});
    }
}