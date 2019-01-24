using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsAuthorTask.Models;
namespace NewsAuthorTask.Models
{
    public class NewsAuthorViewModel
    {
        public IEnumerable<Author> author { get; set; }
        public News news { get; set; }
    }
}