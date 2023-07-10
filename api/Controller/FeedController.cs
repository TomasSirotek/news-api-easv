using api.Dto;
using api.Helpers;
using Infrastructure.DataModel;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controller;

public class FeedController : ControllerBase
{
    private readonly IArticleService _articleService;
    private readonly ResponseHelper _response;
    
    public FeedController(IArticleService articleService, ResponseHelper response)
    {
        _articleService = articleService;
        _response = response;
    }
    
    // http://localhost:5000/api/feed
    [HttpGet]  
    [Route("/api/feed")]
    public ResponseDto GetArticlesForFeed()
    {
        IEnumerable<Article> articles =
            _articleService.GetAllArticles();
        return _response.Success(HttpContext, 200, "Successfully fetched feed", articles);
    }
}