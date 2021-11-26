﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record UserDto(
        int Id,
        string UserName,
        string Name,
        string Summary,
        string Location,
        IEnumerable<ArticleDto> Articles,
        IEnumerable<SubscriberDto> Subscribers,
        IEnumerable<ListingDto> Listings,
        DateTime JoinedAt,
        int OrganizationId,
        OrganizationDto Organization,
        string ImageUrl);
}