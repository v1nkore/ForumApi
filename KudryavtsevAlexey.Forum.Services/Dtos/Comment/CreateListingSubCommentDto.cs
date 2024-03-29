﻿using System;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record CreateListingSubCommentDto(
        string Content,
        int UserId,
        int ListingMainCommentId,
        int ListingId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
