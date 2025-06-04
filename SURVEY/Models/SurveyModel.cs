using System.ComponentModel.DataAnnotations;

namespace SURVEY.Models
{
    public class SurveyModel
    {
        [Key] 
        public int Id { get; set; } 

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public required string Surname { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<string> FavouriteFoods { get; set; } = new List<string>();

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Movies { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Radio { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Out { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int TV { get; set; }
    }
}
