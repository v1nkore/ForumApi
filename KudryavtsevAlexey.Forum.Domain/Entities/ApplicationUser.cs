﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class ApplicationUser : IdentityUser<int>
    {
		public string Name { get; set; }

		public string? Summary { get; set; }

		public string Location { get; set; }

		public DateTime JoinedAt { get; set; } = DateTime.UtcNow.Date;

		public ICollection<Article> Articles { get; set; }

		public ICollection<Listing> Listings { get; set; }

		public ICollection<Subscriber> Subscribers { get; set; }

		public ICollection<Subscription> Subscriptions { get; set; }

		public int OrganizationId { get; set; }

		public Organization Organization { get; set; }

        public ApplicationUser()
        {
            Articles = new List<Article>();
            Listings = new List<Listing>();
			Subscribers = new List<Subscriber>();
			Subscriptions = new List<Subscription>();
        }
    }
}
