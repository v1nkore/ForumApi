﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleMainCommentNotFoundException : NotFoundException
    {
        public ArticleMainCommentNotFoundException(int id)
            :base($"Article main comment with identifier {id} was not found")
        {
            
        }
    }
}