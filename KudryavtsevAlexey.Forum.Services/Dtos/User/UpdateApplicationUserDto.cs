﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record UpdateApplicationUserDto(
        string Name,
        string UserName,
        string Summary,
        string Location);
}
