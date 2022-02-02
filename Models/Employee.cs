using System;
using System.Collections.Generic;

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public int DispatchNumber { get; set; }
        public bool IsEmployed { get; set; }
        public int? Schedules { get; set; }

        public virtual ICollection<Break> Breaks { get; set; }
        public virtual ICollection<Dth> Dths { get; set; }
        public virtual ICollection<Lunch> Lunches { get; set; }
    }
}
