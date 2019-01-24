using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace NewsAuthorTask.Models
{
    public class News
    {
        public Nullable<int>  id { get; set; }
       [Required]
       [Display(Name = "Title")]
        public string newstitle { get; set; }

       [Required]
       [Display(Name = "Content")]
        public string newscontent { get; set; }

         [Display(Name = "Image")]
        public string newsimg { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "publication date")]
        [WithinAweek]
        public DateTime publicationDate { get; set; }

       [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
       [Display(Name = "creation date")]
        public DateTime creationDate { get; set; }
        [Required]
        public int Authorid { get; set; }
        public Author author { get; set; }
    }
}