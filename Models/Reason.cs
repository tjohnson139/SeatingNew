using System;
using System.Collections.Generic;

#nullable disable

namespace Seating.Models
{
    public partial class Reason
    {
        public Reason()
        {
            Lunches = new HashSet<Lunch>();
        }

        public int Id { get; set; }
        public string ReasonName { get; set; }

        public virtual ICollection<Lunch> Lunches { get; set; }
    }
}
