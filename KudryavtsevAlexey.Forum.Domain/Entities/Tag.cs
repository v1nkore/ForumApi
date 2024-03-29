﻿using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Listing> Listings { get; set; }

        public Tag()
        {
            Articles = new List<Article>();
            Listings = new List<Listing>();
        }
    }
}
