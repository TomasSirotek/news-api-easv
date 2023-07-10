using api.ActionFilter;
using api.Dto;
using api.Dto.Article;
using api.Helpers;
using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controller
{
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ResponseHelper _response;

        public ArticleController(IArticleService articleService, ResponseHelper response)
        {
            _articleService = articleService;
            _response = response;
        }
        
        // SEARCH BY ARTICLES
        [HttpGet]
        [ValidateModelFilter]
        [Route("/api/articles")]
        public ResponseDto SearchArticles([FromQuery] ArticleSearchDto searchDto)
        {
            IEnumerable<ArticleQueryModel> articles = _articleService.SearchArticles(searchDto.SearchTerm, searchDto.PageSize);
            return _response.Success(HttpContext, 200, "Successfully fetched articles", articles);
        }
        
        // GET BY ID 
        [HttpGet]
        [Route("/api/articles/{articleId}")]
        public ResponseDto GetArticleById(
            [FromRoute] int articleId)
        {
            Article user = _articleService.GetArticleById(articleId);
            return _response.Success(HttpContext, 200, "Article found", user);
        }
        
        // CREATE ARTICLE
        [HttpPost]
        [ValidateModelFilter]
        [Route("/api/articles")]
        public ResponseDto CreateArticle([FromBody] PostArticleDto articleRequest)
        {
            return _response.Success(
                HttpContext, 201, 
                $"Successfully create article with headline: {articleRequest.Headline}",
                _articleService.CreateArticle(articleRequest.Headline,articleRequest.Author,articleRequest.ArticleImgUrl,articleRequest.Body));
        }
        
        // UPDATE ARTICLE 
        [HttpPut]
        [ValidateModelFilter]
        [Route("/api/articles/{articleId}")]
        public ResponseDto UpdateArticleById(int articleId,[FromBody] PutArticleDto articleDto)
        {
            Article result = _articleService.UpdateArticle(articleId, articleDto.Headline, articleDto.Author, articleDto.ArticleImgUrl, articleDto.Body);
            return _response.Success(HttpContext, 200, $"Article with ID: {articleId} was updated", result);   
        }

        // DELETE ARTICLE 
        [HttpDelete]
        [Route("/api/articles/{articleId}")]
        public ResponseDto DeleteArticleById([FromRoute] int articleId)
        {
            bool result = _articleService.DeleteArticleById(articleId);
            return _response.Success(HttpContext, 201, $"Article with: {articleId} was deleted", result);
        }
    }
}