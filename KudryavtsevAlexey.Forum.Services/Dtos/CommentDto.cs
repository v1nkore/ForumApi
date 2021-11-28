﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record CommentDto(
        int Id,
        string Name,
        DateTime CreatedAt) : BaseDto(Id);
}
