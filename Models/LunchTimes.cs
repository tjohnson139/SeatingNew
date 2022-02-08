using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seating.Models
{
    public class LunchTimes
    {
        [Key]
        public int Id { get; set; }
        public string ShiftStart { get; set; }
        public string LunchHour { get; set; }
        public string LunchMinute { get; set; }
    }
}
