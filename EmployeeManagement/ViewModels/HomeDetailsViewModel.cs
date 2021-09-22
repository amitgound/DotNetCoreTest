using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }

        public string PageHeader { get; set; }

        public decimal tdecimal { get; set; }
        public double tdouble { get; set; }
    }

}
