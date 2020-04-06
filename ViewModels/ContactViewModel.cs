using System.ComponentModel.DataAnnotations;
namespace DutchTreat.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }        
        [Required]
        [MinLength(5)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too long, must be 50 characters or less")]
        public string Text { get; set; }


    }
}