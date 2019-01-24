using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace NewsAuthorTask.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between 2 and 20 characters.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
     
      
        public ICollection<News> news { get; set; }
    }
}