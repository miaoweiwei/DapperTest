﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperTest
{
    //书评
    public class BookReview
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual string Content { get; set; }
        public virtual Book AssoicationWithBook { get; set; }
        public override string ToString()
        {
            return string.Format("{0})--[{1}]\t\"{3}\"", Id, BookId, Content);
        }
    }
}
