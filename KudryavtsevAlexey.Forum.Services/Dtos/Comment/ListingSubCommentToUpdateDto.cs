﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ListingSubCommentToUpdateDto(
        string Content,
        int UserId,
        int ListingMainCommentId,
        int ListingId);
}
