using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
namespace Restauranter.Models
{
    public abstract class BaseEntity{}
    public class Review 
    {
        [Key]
        public int id {get; set;}
        [Required]
        public string reviewer {get; set;}
        [Required]
        public string restaurant {get; set;}
        [Required]
        public string review {get; set;}
        [Required]
        [ValidDateAttribute]
        public DateTime date {get; set;}
        [Required]
        public int stars {get; set;}
    }
    
    public class ValidDateAttribute : ValidationAttribute
    {
        private DateTime _today = DateTime.Now;


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Review restaurant = (Review)validationContext.ObjectInstance;
            if(_today >= restaurant.date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date must be not be in the future");
            }
        }
    }
}