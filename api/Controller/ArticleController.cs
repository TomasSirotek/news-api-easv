using api.Dto;
using api.Dto.Article;
using api.Helpers;
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
        
        [HttpPost]
        [Route("/api/articles")]
        public ResponseDto CreateArticle([FromBody] CreateArticleDto articleRequest)
        {
            return _response.Success(
                HttpContext, 201, 
                $"Successfully create article with headline: {articleRequest.Headline}",
                _articleService.CreateArticle(articleRequest.Headline,articleRequest.Author,articleRequest.ArticleImgUrl,articleRequest.Body));
        }
    }
}