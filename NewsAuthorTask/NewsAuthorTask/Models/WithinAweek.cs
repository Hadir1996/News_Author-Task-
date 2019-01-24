using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace NewsAuthorTask.Models
{
    public class WithinAweek : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var news=(News)validationContext.ObjectInstance;
            if(news.publicationDate == null){
             return new ValidationResult("Publication date is required");
            }

            else{

            if(news.publicationDate <= DateTime.Now.AddDays(7)){
                return ValidationResult.Success;
            }
            else{
                return new ValidationResult("Publication date should be between today and a week from today");
            }
            }
           

            }
        }
    }
