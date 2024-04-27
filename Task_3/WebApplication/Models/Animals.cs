using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Animals
    {
        public int IdAnimal
        { 
            get;
            init; 
        }

        [Required]
        [MaxLength(100)]
        public string? Name
        { 
            get; 
            init; 
        }

        [MaxLength(100)]
        public string? Description
        { 
            get; 
            init; 
        }

        [Required]
        [MaxLength(100)]
        public string? Category
        { 
            get; 
            init; 
        }

        [Required]
        [MaxLength(100)]
        public string? Area
        { 
            get; 
            init; 
        }
    }
}
