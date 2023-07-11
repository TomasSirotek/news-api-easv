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

    public async Task<IEnumerable<ArticleQueryModel>> SearchArticles(string searchDtoSearchTerm, int searchDtoPageSize)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();

        const string sql = @"SELECT article_id AS ArticleId, author, headline
                         FROM news.articles
                         WHERE (author ILIKE '%' || @searchDtoSearchTerm || '%' OR
                                headline ILIKE '%' || @searchDtoSearchTerm || '%')
                         LIMIT @searchDtoPageSize";

        return await connection.QueryAsync<ArticleQueryModel>(sql, new { searchDtoSearchTerm, searchDtoPageSize });
    }

    public async Task<IEnumerable<ArticleFeedModel>> GetAllArticlesForFeed()
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "SELECT article_id AS ArticleId, headline, article_img_url AS ArticleImgUrl, SUBSTRING(body, 1, 51) AS body FROM news.articles";

        return await connection.QueryAsync<ArticleFeedModel>(sql);
    }

    public async Task<Article> GetArticleById(int articleId)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "SELECT article_id AS ArticleId,author, headline, article_img_url AS ArticleImgUrl, body FROM news.articles WHERE article_id = @articleId";
        
        return await connection.QueryFirstAsync<Article>(sql, new { articleId });
    }

    public async Task<Article> CreateArticle(string headline, string author, string articleImgUrl,
        string articleBody)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "INSERT INTO news.articles (headline, author, article_img_url, body) VALUES (@headline, @author, @articleImgUrl, @articleBody) RETURNING article_id as ArticleId, headline, author, article_img_url as ArticleImgUrl, body";
        
        return await connection.QueryFirstAsync<Article>(sql, new { headline, author, articleImgUrl, articleBody });
    }

    public async Task<Article> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline,
        string articleDtoAuthor,
        string articleDtoArticleImgUrl, string articleDtoBody)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "UPDATE news.articles SET headline = @articleDtoHeadline, author = @articleDtoAuthor, article_img_url = @articleDtoArticleImgUrl, body = @articleDtoBody WHERE article_id = @articleDtoArticleId RETURNING article_id as ArticleId, headline, author, article_img_url as ArticleImgUrl, body";
        
        return await connection.QueryFirstAsync<Article>(sql,
            new { articleDtoArticleId, articleDtoHeadline, articleDtoAuthor, articleDtoArticleImgUrl, articleDtoBody });
    }

    public async Task<bool> DeleteArticleById(int articleId)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql = "DELETE FROM news.articles WHERE article_id = @articleId";
        
        return await connection.ExecuteAsync(sql, new { articleId }) > 0;
    }
}