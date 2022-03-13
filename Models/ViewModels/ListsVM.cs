using Seating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seating.ViewModels
{
    public class ListsVM
    {
        public ListsVM()
        {
            Employees = new List<Employee>();
            Positions = new List<Position>();
        }
        public IEnumerable<Dth> Dths { get; set; }
        public IEnumerable<Break> Breaks { get; set; }
        public IEnumerable<Lunch> Lunches { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public int EmployeeId { get; set; }
        public int EmpPosition { get; set; }
        public bool EmpSent { get; set; }
        public bool LunchTime { get; set; }
        public bool LongerLunch { get; set; }
        public bool DblLunch { get; set; }
    }
}
