using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Seating.Models
{
    public partial class Position
    {
        public Position()
        {
            BreakEmpPositionNavigations = new HashSet<Break>();
            BreakRlfPositionNavigations = new HashSet<Break>();
            DthEmpPositionNavigations = new HashSet<Dth>();
            DthRlfPositionNavigations = new HashSet<Dth>();
            LunchEmpPositionNavigations = new HashSet<Lunch>();
            LunchRlfPositionNavigations = new HashSet<Lunch>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(7, ErrorMessage = "No more than 7 characters")]
        public string PositionName { get; set; }
        public bool Inactive { get; set; }

        public virtual ICollection<Break> BreakEmpPositionNavigations { get; set; }
        public virtual ICollection<Break> BreakRlfPositionNavigations { get; set; }
        public virtual ICollection<Dth> DthEmpPositionNavigations { get; set; }
        public virtual ICollection<Dth> DthRlfPositionNavigations { get; set; }
        public virtual ICollection<Lunch> LunchEmpPositionNavigations { get; set; }
        public virtual ICollection<Lunch> LunchRlfPositionNavigations { get; set; }
    }
}
