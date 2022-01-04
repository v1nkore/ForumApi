﻿using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
{
    public class DbContextHelper
    {
        public ForumDbContext Context { get; set; }

        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<ForumDbContext>();

            builder.UseInMemoryDatabase("TestForumDb")
                .ConfigureWarnings(x=>x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;

            Context = new ForumDbContext(options);

			var organizations = OrganizationHelper.GetMany();
			organizations.Add(OrganizationHelper.GetOne());

			var articles = ArticleHelper.GetMany();
			articles.Add(ArticleHelper.GetOne());

			var listings = ListingHelper.GetMany();
			listings.Add(ListingHelper.GetOne());

			var tags = TagHelper.GetMany();
			tags.Add(TagHelper.GetOne());

			var users = UserHelper.GetMany();
			users.Add(UserHelper.GetOne());

			var articleMainComments = ArticleMainCommentHelper.GetMany();
			articleMainComments.Add(ArticleMainCommentHelper.GetOne());

			var listingMainComments = ListingMainCommentHelper.GetMany();
			listingMainComments.Add(ListingMainCommentHelper.GetOne());

			var articleSubComments = ArticleSubCommentHelper.GetMany();
			articleSubComments.Add(ArticleSubCommentHelper.GetOne());

			var listingSubComments = ListingSubCommentHelper.GetMany();
			listingSubComments.Add(ListingSubCommentHelper.GetOne());

			for (int i = 0; i < organizations.Count; i++)
			{
				organizations[i].Users.Add(users[i]);

				articles[i].MainComments.Add(articleMainComments[i]);
				articles[i].Tags.Add(tags[i]);
				articles[i].User = users[i];

				listings[i].MainComments.Add(listingMainComments[i]);
				listings[i].Tags.Add(tags[i]);
				listings[i].User = users[i];

				tags[i].Articles.Add(articles[i]);
				tags[i].Listings.Add(listings[i]);

				users[i].Articles.Add(articles[i]);
				users[i].Listings.Add(listings[i]);
				users[i].Organization = organizations[i];
				users[i].Subscribers = new List<Subscriber>() {new Subscriber() {User = users[(i+1)%4]}};

				articleMainComments[i].Article = articles[i];
				articleMainComments[i].SubComments.Add(articleSubComments[i]);
				articleMainComments[i].User = users[i];

				listingMainComments[i].Listing = listings[i];
				listingMainComments[i].SubComments.Add(listingSubComments[i]);
				listingMainComments[i].User = users[i];

				articleSubComments[i].Article = articles[i];
				articleSubComments[i].ArticleMainComment = articleMainComments[i];
				articleSubComments[i].User = users[i];

				listingSubComments[i].Listing = listings[i];
				listingSubComments[i].ListingMainComment = listingMainComments[i];
				listingSubComments[i].User = users[i];
			}

			Context.Organizations.AddRange(organizations);
			Context.Articles.AddRange(articles);
			Context.Listings.AddRange(listings);
			Context.Tags.AddRange(tags);
			Context.Users.AddRange(users);
			Context.ArticleMainComments.AddRange(articleMainComments);
			Context.ListingMainComments.AddRange(listingMainComments);
			Context.ArticleSubComments.AddRange(articleSubComments);
			Context.ListingSubComments.AddRange(listingSubComments);

			Context.SaveChanges();
        }
    }
}
