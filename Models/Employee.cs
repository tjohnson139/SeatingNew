using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Seating.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Breaks = new HashSet<Break>();
            Dths = new HashSet<Dth>();
            Lunches = new HashSet<Lunch>();
        }

        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please. Place the Dispatch Number in the next field")]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Please enter the last two numbers of the dispatch number only")]
        [Display(Name = "Dispatch Number")]
        public int DispatchNumber { get; set; }
        public bool IsEmployed { get; set; } = true;
        public int? Schedules { get; set; }

        public virtual ICollection<Break> Breaks { get; set; }
        public virtual ICollection<Dth> Dths { get; set; }
        public virtual ICollection<Lunch> Lunches { get; set; }
    }
}
