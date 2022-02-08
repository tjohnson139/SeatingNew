using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seating.Models;
using Seating.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Seating.Controllers
{
    public class HomeController : Controller
    {
        private readonly db_a7e17a_seatingContext _context = new db_a7e17a_seatingContext();

        public HomeController(db_a7e17a_seatingContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var tables = new ListsVM
            {
                Employees = _context.Employees.ToList(),
                Dths = _context.Dths.Where(n => n.TimeCleared == null).OrderBy(n => n.TimeEntered).ToList(),
                Breaks = _context.Breaks.Where(n => n.TimeCleared == null).OrderBy(n => n.TimeEntered).ToList(),
                Lunches = _context.Lunches.Where(n => n.TimeCleared == null).OrderBy(n => n.LunchTime).ToList(),
                Positions = _context.Positions.ToList(),
                LunchTime = _context.LunchTimes.ToList()
            };

            //Controls what populates the "off the floor" number on the home page
            TimeSpan time = DateTime.Now.TimeOfDay;

            var fireCounted = new bool();

            if (time > new TimeSpan(00, 00, 01) && time < new TimeSpan(10, 00, 00))
            {
                fireCounted = true;
            }            

            ViewData["offFloor"] = tables.Breaks.Where(n => n.TimeCleared == null && n.EmpSent == true).Count() + tables.Dths.Where(n => n.EmpSent == true && n.TimeCleared == null).Count() + tables.Lunches.Where(n => n.EmpSent == true && n.TimeCleared == null && (fireCounted.Equals(true) || (fireCounted.Equals(false) && n.EmpPositionNavigation.PositionName != "FR" && n.EmpPositionNavigation.PositionName != "FL" && n.EmpPositionNavigation.PositionName != "FC"))).Count();

            ViewData["fireCounted"] = fireCounted;


            //Start Lunch List Population
            var dt = DateTime.Now;


            ////////////////////////////////////////////////////////////////////0400 Shift Start time
            List<string> fourAM = new List<string>();
            var eight30 = new bool();
            var nine = new bool();
            var nine30 = new bool();
            var ten = new bool();

            //08:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 08 && item.LunchTime.Minute == 30)
                {
                    eight30 = true;
                    break;
                }
            }                

            if (eight30 == false)
            {
                fourAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //09:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 09 && item.LunchTime.Minute == 00)
                {
                    nine = true;
                    break;
                }
            }

            if (nine == false)
            {
                fourAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //09:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 09 && item.LunchTime.Minute == 30)
                {
                    nine30 = true;
                    break;
                }
            }

            if (nine30 == false)
            {
                fourAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //10:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 10 && item.LunchTime.Minute == 00)
                {
                    ten = true;
                    break;
                }
            }

            if (ten == false)
            {
                fourAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //////////////////////////////////////////////////////////////////////////////////////////0600 Shift Start time
            List<string> sixAM = new List<string>();
            var ten30 = new bool();
            var eleven = new bool();
            var eleven30 = new bool();
            var twelve = new bool();

            //10:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 10 && item.LunchTime.Minute == 30)
                {
                    ten30 = true;
                    break;
                }
            }

            if (ten30 == false)
            {
                sixAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //11:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 11 && item.LunchTime.Minute == 00)
                {
                    eleven = true;
                    break;
                }
            }

            if (eleven == false)
            {
                sixAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //11:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 11 && item.LunchTime.Minute == 30)
                {
                    eleven30 = true;
                    break;
                }
            }

            if (eleven30 == false)
            {
                sixAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //12:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 12 && item.LunchTime.Minute == 00)
                {
                    twelve = true;
                    break;
                }
            }

            if (twelve == false)
            {
                sixAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 00).ToString("M/d/yy HH:mm"));
            }


            ///////////////////////////////////////////////////////////////////////////////////0800 Shift Start time
            List<string> eightAM = new List<string>();
            var twelve30 = new bool();
            var thirteen = new bool();
            var thirteen30 = new bool();
            var fourteen = new bool();
            var fourteen30 = new bool();

            //12:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 12 && item.LunchTime.Minute == 30)
                {
                    twelve30 = true;
                    break;
                }
            }

            if (twelve30 == false)
            {
                eightAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //13:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 13 && item.LunchTime.Minute == 00)
                {
                    thirteen = true;
                    break;
                }
            }

            if (thirteen == false)
            {
                eightAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //13:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 13 && item.LunchTime.Minute == 30)
                {
                    thirteen30 = true;
                    break;
                }
            }

            if (thirteen30 == false)
            {
                eightAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //14:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 14 && item.LunchTime.Minute == 00)
                {
                    fourteen = true;
                    break;
                }
            }

            if (fourteen == false)
            {
                eightAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //14:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 14 && item.LunchTime.Minute == 30)
                {
                    fourteen30 = true;
                    break;
                }
            }

            if (fourteen30 == false)
            {
                eightAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 00).ToString("M/d/yy HH:mm"));
            }


            //////////////////////////////////////////////////////////////////////////////////////1000 Shift Start time
            List<string> tenAM = new List<string>();
            var fifteen = new bool();
            var fifteen30 = new bool();
            var sixteen = new bool();
            var sixteen30 = new bool();

            //15:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 15 && item.LunchTime.Minute == 00)
                {
                    fifteen = true;
                    break;
                }
            }

            if (fifteen == false)
            {
                tenAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //15:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 15 && item.LunchTime.Minute == 30)
                {
                    fifteen30 = true;
                    break;
                }
            }

            if (fifteen30 == false)
            {
                tenAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //16:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 16 && item.LunchTime.Minute == 00)
                {
                    sixteen = true;
                    break;
                }
            }

            if (sixteen == false)
            {
                tenAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //16:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 16 && item.LunchTime.Minute == 30)
                {
                    sixteen30 = true;
                    break;
                }
            }

            if (sixteen30 == false)
            {
                tenAM.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 00).ToString("M/d/yy HH:mm"));
            }


            /////////////////////////////////////////////////////////////////////////////////1200 Shift Start time
            List<string> noon = new List<string>();
            var seventeen = new bool();
            var seventeen30 = new bool();
            var eighteen = new bool();

            //17:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 17 && item.LunchTime.Minute == 00)
                {
                    seventeen = true;
                    break;
                }
            }

            if (seventeen == false)
            {
                noon.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //17:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 17 && item.LunchTime.Minute == 30)
                {
                    seventeen30 = true;
                    break;
                }
            }

            if (seventeen30 == false)
            {
                noon.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //18:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 18 && item.LunchTime.Minute == 00)
                {
                    eighteen = true;
                    break;
                }
            }

            if (eighteen == false)
            {
                noon.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 00).ToString("M/d/yy HH:mm"));
            }


            //////////////////////////////////////////////////////////////////////////////////////////////1400 Shift Start time
            List<string> fourteenhundred = new List<string>();
            var eighteen30 = new bool();
            var nineteen = new bool();
            var nineteen30 = new bool();
            var twenty = new bool();


            //18:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 18 && item.LunchTime.Minute == 30)
                {
                    eighteen30 = true;
                    break;
                }
            }

            if (eighteen30 == false)
            {
                fourteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //19:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 19 && item.LunchTime.Minute == 00)
                {
                    nineteen = true;
                    break;
                }
            }

            if (nineteen == false)
            {
                fourteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //19:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 19 && item.LunchTime.Minute == 30)
                {
                    nineteen30 = true;
                    break;
                }
            }

            if (nineteen30 == false)
            {
                fourteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //20:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 20 && item.LunchTime.Minute == 00)
                {
                    twenty = true;
                    break;
                }
            }

            if (twenty == false)
            {
                fourteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 00).ToString("M/d/yy HH:mm"));
            }


            /////////////////////////////////////////////////////////////////////////////////////////////////1600 Shift Start time
            List<string> sixteenhundred = new List<string>();
            var twenty30 = new bool();
            var twentyone = new bool();
            var twentyone30 = new bool();
            var twentytwo = new bool();


            //20:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 20 && item.LunchTime.Minute == 30)
                {
                    twenty30 = true;
                    break;
                }
            }

            if (twenty30 == false)
            {
                sixteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //21:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 21 && item.LunchTime.Minute == 00)
                {
                    twentyone = true;
                    break;
                }
            }

            if (twentyone == false)
            {
                sixteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //21:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 21 && item.LunchTime.Minute == 30)
                {
                    twentyone30 = true;
                    break;
                }
            }

            if (twentyone30 == false)
            {
                sixteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //22:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 22 && item.LunchTime.Minute == 00)
                {
                    twentytwo = true;
                    break;
                }
            }

            if (twentytwo == false)
            {
                sixteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 00).ToString("M/d/yy HH:mm"));
            }



            ////////////////////////////////////////////////////////////////////////////////////////////1800 Shift Start time
            List<string> eighteenhundred = new List<string>();
            var twentytwo30 = new bool();
            var twentythree = new bool();
            var twentythree30 = new bool();
            var midnight = new bool();
            var midnight30 = new bool();


            //22:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 22 && item.LunchTime.Minute == 30)
                {
                    twentytwo30 = true;
                    break;
                }
            }

            if (twentytwo30 == false)
            {
                eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 00).ToString("M/d/yy HH:mm"));
            }

            //23:00 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 23 && item.LunchTime.Minute == 00)
                {
                    twentythree = true;
                    break;
                }
            }

            if (twentythree == false)
            {
                eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 00).ToString("M/d/yy HH:mm"));
            }

            //23:30 lunch
            foreach (var item in tables.Lunches)
            {
                if (item.LunchTime.Hour == 23 && item.LunchTime.Minute == 30)
                {
                    twentythree30 = true;
                    break;
                }
            }

            if (twentythree30 == false)
            {
                eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 00).ToString("M/d/yy HH:mm"));
            }


            ///// 1800 time deliniation
            if (dt.Hour <= 23)
            {
                ///////00:00 lunch before midnight
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 00 && item.LunchTime.Minute == 00)
                    {
                        midnight = true;
                        break;
                    }
                }

                if (midnight == false)
                {
                    eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //00:30 lunch before midnight
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 00 && item.LunchTime.Minute == 30)
                    {
                        midnight30 = true;
                        break;
                    }
                }

                if (midnight30 == false)
                {
                    eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }
                ///////////////////////After midnight
            } else
            {
                //00:00 lunch after midnight
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 00 && item.LunchTime.Minute == 00)
                    {
                        midnight = true;
                        break;
                    }
                }

                if (midnight == false)
                {
                    eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00).ToString("M/d/yy HH:mm"));
                }

                //////////////00:30 lunch after midnight
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 00 && item.LunchTime.Minute == 30)
                    {
                        midnight30 = true;
                        break;
                    }
                }

                if (midnight30 == false)
                {
                    eighteenhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 00).ToString("M/d/yy HH:mm"));
                }
            }


            ///////////////////////////2000 Shift Start time
            List<string> twentyhundred = new List<string>();
            var one = new bool();
            var one30 = new bool();
            var two = new bool();
            var two30 = new bool();
            var three = new bool();

            if (dt.Hour <= 23)
            {
                //01:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 01 && item.LunchTime.Minute == 00)
                    {
                        one = true;
                        break;
                    }
                }

                if (one == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //01:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 01 && item.LunchTime.Minute == 30)
                    {
                        one30 = true;
                        break;
                    }
                }

                if (one30 == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //02:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 02 && item.LunchTime.Minute == 00)
                    {
                        two = true;
                        break;
                    }
                }

                if (two == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //02:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 02 && item.LunchTime.Minute == 30)
                    {
                        two30 = true;
                        break;
                    }
                }

                if (two30 == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //03:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 03 && item.LunchTime.Minute == 00)
                    {
                        three = true;
                        break;
                    }
                }

                if (three == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }
            }
            //After midnight
            else
            {
                //01:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 01 && item.LunchTime.Minute == 00)
                    {
                        one = true;
                        break;
                    }
                }

                if (one == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 00).ToString("M/d/yy HH:mm"));
                }

                //01:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 01 && item.LunchTime.Minute == 30)
                    {
                        one30 = true;
                        break;
                    }
                }

                if (one30 == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 00).ToString("M/d/yy HH:mm"));
                }

                //02:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 02 && item.LunchTime.Minute == 00)
                    {
                        two = true;
                        break;
                    }
                }

                if (two == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 00).ToString("M/d/yy HH:mm"));
                }

                //02:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 02 && item.LunchTime.Minute == 30)
                    {
                        two30 = true;
                        break;
                    }
                }

                if (two30 == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 00).ToString("M/d/yy HH:mm"));
                }

                //03:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 03 && item.LunchTime.Minute == 00)
                    {
                        three = true;
                        break;
                    }
                }

                if (three == false)
                {
                    twentyhundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 00).ToString("M/d/yy HH:mm"));
                }
            }

            ///////////////////////////2200 Shift Start time
            List<string> twentytwohundred = new List<string>();
            var three30 = new bool();
            var four = new bool();
            var four30 = new bool();

            if (dt.Hour <= 23)
            {
                //03:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 03 && item.LunchTime.Minute == 30)
                    {
                        three30 = true;
                        break;
                    }
                }

                if (three30 == false)
                {
                    twentytwohundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //04:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 04 && item.LunchTime.Minute == 00)
                    {
                        four = true;
                        break;
                    }
                }

                if (four == false)
                {
                    twentytwohundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }

                //04:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 04 && item.LunchTime.Minute == 30)
                    {
                        four30 = true;
                        break;
                    }
                }

                if (four30 == false)
                {
                    twentytwohundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 00).AddDays(1).ToString("M/d/yy HH:mm"));
                }
            }
            /////After midnight
            else
            {
                //03:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 03 && item.LunchTime.Minute == 30)
                    {
                        three30 = true;
                        break;
                    }
                }

                if (three30 == false)
                {
                    twentytwohundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 00).ToString("M/d/yy HH:mm"));
                }

                //04:00 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 04 && item.LunchTime.Minute == 00)
                    {
                        four = true;
                        break;
                    }
                }

                if (four == false)
                {
                    twentytwohundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 00).ToString("M/d/yy HH:mm"));
                }

                //04:30 lunch
                foreach (var item in tables.Lunches)
                {
                    if (item.LunchTime.Hour == 04 && item.LunchTime.Minute == 30)
                    {
                        four30 = true;
                        break;
                    }
                }

                if (four30 == false)
                {
                    twentytwohundred.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 00).ToString("M/d/yy HH:mm"));
                }
            }


            ViewBag.fourAM = fourAM;
            ViewBag.sixAM = sixAM;
            ViewBag.eightAM = eightAM;
            ViewBag.tenAM = tenAM;
            ViewBag.noon = noon;
            ViewBag.fourteenhundred = fourteenhundred;
            ViewBag.sixteenhundred = sixteenhundred;
            ViewBag.eighteenhundred = eighteenhundred;
            ViewBag.twentyhundred = twentyhundred;
            ViewBag.twentytwohundred = twentytwohundred;


            return View(tables);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
