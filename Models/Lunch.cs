using System;
using System.Collections.Generic;

#nullable disable

namespace Seating.Models
{
    public partial class Lunch
    {
        public int Id { get; set; }
        public DateTime TimeEntered { get; set; }
        public DateTime? TimeCleared { get; set; }
        public bool? EmpSent { get; set; }
        public DateTime LunchTime { get; set; }
        public int EmployeeId { get; set; }
        public int? ReasonId { get; set; }
        public int EmpPosition { get; set; }
        public int? RlfPosition { get; set; }
        public bool? LongerLunch { get; set; }
        public bool? DblLunch { get; set; }

        public virtual Position EmpPositionNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Reason Reason { get; set; }
        public virtual Position RlfPositionNavigation { get; set; }
    }
}
