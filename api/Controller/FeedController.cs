using api.Dto;
using api.Helpers;
using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Service.Interface;

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

    #region GET
    // It should be possible to get a list of recent news stories on the landing page (a feed).
    // These posts should only include some of the article text (body): a max of 51 characters is allowed here 
    [HttpGet]  
    [Route("/api/feed")]
    public async Task<ResponseDto> GetArticlesForFeed()
    {
        var articles =
            await _articleService.GetAllArticlesForFeed();
        return _response.CreateResponse(HttpContext, StatusCodeType.Success, "Successfully fetched feed", articles);
    }
    #endregion
}