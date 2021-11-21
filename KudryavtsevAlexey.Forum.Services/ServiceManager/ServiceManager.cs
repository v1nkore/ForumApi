﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Services;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

namespace KudryavtsevAlexey.Forum.Services.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArticleService> _lazyArticleService;
        private readonly Lazy<ICommentService> _lazyCommentService;
        private readonly Lazy<IListingService> _lazyListingService;
        private readonly Lazy<IOrganizationService> _lazyOrganizationService;
        private readonly Lazy<ITagService> _lazyTagService;
        private readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(ForumDbContext dbContext)
        {
            _lazyArticleService = new Lazy<IArticleService>(() => new ArticleService(dbContext));
            _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(dbContext));
            _lazyListingService = new Lazy<IListingService>(() => new ListingService(dbContext));
            _lazyOrganizationService = new Lazy<IOrganizationService>(() => new OrganizationService(dbContext));
            _lazyTagService = new Lazy<ITagService>(() => new TagService(dbContext));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(dbContext));
        }

        public IArticleService ArticleService => _lazyArticleService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;
        public IListingService ListingService => _lazyListingService.Value;
        public IOrganizationService OrganizationService => _lazyOrganizationService.Value;
        public ITagService TagService => _lazyTagService.Value;
        public IUserService UserService => _lazyUserService.Value;
    }
}