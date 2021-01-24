using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodingChallenge.Domain
{
   public class InsuredInput
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than or equal to 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(0, 150, ErrorMessage = "Age must be numeric, greater than 0, and equal to 150")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Death-Sum Insured is required")]
        [Range(0, 9999999999.99, ErrorMessage = "Death-Sum Insured must be numeric, greater than 0, and smaller than 10000000000")]
        public Decimal DeathSumInsured { get; set; }

        [Required(ErrorMessage = "Occupation is required")]
        public string Occupation { get; set; }
    }
}
