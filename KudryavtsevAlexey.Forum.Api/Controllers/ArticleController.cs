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
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _serviceManager.ArticleService.GetArticleById(id);

            return Ok(article);
        }

        /// <summary>
        /// Returns list of the published articles
        /// </summary>
        /// <returns>Published articles</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("published")]
        [Authorize]
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
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("by-date")]
        [Authorize]
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
        /// <response code="404">If article not found</response>
        [HttpGet]
        [Route("published/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticleById(int id)
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
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("user/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticlesByUserId(int id)
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
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("user/{id}/published")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticlesByUserId(int id)
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
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("user/{id}/unpublished")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpublishedArticlesByUserId(int id)
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
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("user/{id}/all")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllArticlesByUserId(int id)
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
        /// <returns>Ok if article added</returns>
        /// <response code="201">Returns ok if article added</response>
        [HttpPost]
        [Route("creating")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticle(ArticleDto articleDto)
        {
            await _serviceManager.ArticleService.AddArticle(articleDto);

            return Ok(articleDto);
        }

        /// <summary>
        /// Updates article
        /// </summary>
        /// <returns>Ok if article updated</returns>
        /// <response code="200">Returns ok if article updated</response>
        [HttpPut]
        [Route("updating/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateArticle(int id, PutArticleDto articleDto)
        {
            await _serviceManager.ArticleService.UpdateArticle(id, articleDto);

            return Ok(articleDto);
        }
    }
}
