using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsAuthorTask.Models
{
    public class Authornews
    {
        public Author author { get; set; }
        public News news { get; set; }
    }
}