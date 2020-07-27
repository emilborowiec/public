using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PP.ValidatedInputService.Api.Models
{
    public class Movie : IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public DateTime Release { get; set; }
        public int Runtime { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string StoryBy { get; set; }
        [Required]
        [MinLength(1)]
        public string[] Cast { get; set; }
        [Required]
        [MinLength(1)]
        public string[] Genres { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Year != Release.Year)
            {
                yield return new ValidationResult("Year does not correspond to Release year.", new[] {nameof(Year)});
            }
        }
    }
}