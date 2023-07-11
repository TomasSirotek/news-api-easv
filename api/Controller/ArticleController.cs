using api.ActionFilter;
using api.Dto;
using api.Dto.Article;
using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Interface;

namespace api.Controller;

public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;
    private readonly ResponseHelper _response;

    public ArticleController(IArticleService articleService, ResponseHelper response)
    {
        _articleService = articleService;
        _response = response;
    }
        
    #region GET
    // It should be possible to search for articles.
    [HttpGet]
    [ValidateModelFilter]
    [Route("/api/articles")]
    public async Task<ResponseDto> SearchArticles([FromQuery] ArticleSearchDto searchDto)
    {
        var articles = await _articleService.SearchArticles(searchDto.SearchTerm, searchDto.PageSize);
        return _response.CreateResponse(HttpContext,StatusCodeType.Success, "Successfully fetched articles", articles);
    }
        
    // It should be possible to get the full article with all details
    [HttpGet]
    [Route("/api/articles/{articleId}")]
    public async Task<ResponseDto> GetArticleById(
        [FromRoute] int articleId)
    {
        var user = await _articleService.GetArticleById(articleId);
        return _response.CreateResponse(HttpContext,StatusCodeType.Success, "Article found", user);
    }
        
    #endregion
        
    #region POST
    // It should be possible to create a new article
    [HttpPost]
    [ValidateModelFilter]
    [Route("/api/articles")]
    public async Task<ResponseDto> CreateArticle([FromBody] PostArticleDto articleRequest)
    {
        return _response.CreateResponse(
            HttpContext, StatusCodeType.Created, 
            $"Successfully create article with headline: {articleRequest.Headline}",
            await _articleService.CreateArticle(
                articleRequest.Headline,
                articleRequest.Author,
                articleRequest.ArticleImgUrl,
                articleRequest.Body));
    }
    #endregion

    #region PUT
    // It should be possible to update an article 
    [HttpPut]
    [ValidateModelFilter]
    [Route("/api/articles/{articleId}")]
    public async Task<ResponseDto> UpdateArticleById(int articleId,[FromBody] PutArticleDto articleDto)
    {
        var result = await _articleService.UpdateArticle(articleId, articleDto.Headline, articleDto.Author, articleDto.ArticleImgUrl, articleDto.Body);
        return _response.CreateResponse(HttpContext, StatusCodeType.Success, $"Article with ID: {articleId} was updated", result);   
    }
    #endregion

    #region DELETE
    // It should be possible to delete an article
    [HttpDelete]
    [Route("/api/articles/{articleId}")]
    public async Task<ResponseDto> DeleteArticleById([FromRoute] int articleId)
    {
        var result = await _articleService.DeleteArticleById(articleId);
        return _response.CreateResponse(HttpContext, StatusCodeType.Created, $"Article with: {articleId} was deleted", result);
    }
    #endregion
}