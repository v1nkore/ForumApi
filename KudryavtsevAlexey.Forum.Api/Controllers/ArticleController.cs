﻿using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using Microsoft.AspNetCore.Authorization;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ArticleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns article by id
        /// </summary>
        /// <returns>Article</returns>
        /// <response code="200">Returns article</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If article not found</response>
        [HttpGet]
        [Route("find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleById([FromQuery]int id)
        {
            var article = await _serviceManager.ArticleService.GetArticleById(id);

            return Ok(article);
        }

        /// <summary>
        /// Returns list of the published articles
        /// </summary>
        /// <returns>Published articles</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticles()
        {
            var articles = await _serviceManager.ArticleService.GetPublishedArticles();

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns list of the articles sorted by date
        /// </summary>
        /// <returns>Articles sorted by date</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("by-date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSortedArticlesByDate()
        {
            var articles = await _serviceManager.ArticleService.SortArticlesByDate();

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns published article by id
        /// </summary>
        /// <returns>Published article by id</returns>
        /// <response code="200">Returns article</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If article not found</response>
        [HttpGet]
        [Route("published/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticleById([FromQuery]int id)
        {
            var article = await _serviceManager.ArticleService.GetPublishedArticleById(id);

            if (article is null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        /// <summary>
        /// Returns published articles by user
        /// </summary>
        /// <returns>Published articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("find/userId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticlesByUserId([FromQuery]int id)
        {
            var articles = await _serviceManager.ArticleService.GetArticlesByUserId(id);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns unpublished articles by user
        /// </summary>
        /// <returns>Unpublished articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("find/userId/published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticlesByUserId([FromQuery]int id)
        {
            var articles = await _serviceManager.ArticleService.GetPublishedArticlesByUserId(id);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns unpublished articles by user
        /// </summary>
        /// <returns>Unpublished articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("find/userId/unpublished")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpublishedArticlesByUserId([FromQuery]int id)
        {
            var articles = await _serviceManager.ArticleService.GetUnpublishedArticlesByUserId(id);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns all articles by user
        /// </summary>
        /// <returns>All articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("find/userId/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllArticlesByUserId([FromQuery]int id)
        {
            var articles = await _serviceManager.ArticleService.GetArticlesByUserId(id);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Adds article
        /// </summary>
        /// <returns>Ok if article created</returns>
        /// <response code="201">Returns ok if article added</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticle([FromBody]CreateArticleDto articleDto)
        {
            await _serviceManager.ArticleService.CreateArticle(articleDto);

            return Ok(articleDto);
        }

        /// <summary>
        /// Updates article
        /// </summary>
        /// <returns>Ok if article updated</returns>
        /// <response code="200">Returns ok if article updated</response>
        /// <response code="401">If user not authorized</response>
        [HttpPatch]
        [Route("updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateArticle([FromQuery]int id, [FromBody]UpdateArticleDto articleDto)
        {
            await _serviceManager.ArticleService.UpdateArticle(id, articleDto);

            return Ok(articleDto);
        }

        /// <summary>
        /// Deletes article
        /// </summary>
        /// <returns>Ok if article deleted</returns>
        /// <response code="200">If article deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If user not found</response>
        [HttpDelete]
        [Route("{id}/deleting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticle([FromRoute]int id)
        {
            await _serviceManager.ArticleService.DeleteArticle(id);

            return Ok();
        }
        
    }
}
