using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository )
        {
            _logger = logger;
            _employeeRepository = employeeRepository; 
        }    

        public JsonResult Index()
        {
            //string processname = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            // return processname;
      
       
            //return Newtonsoft.Json.JsonConvert.SerializeObject(_employeeRepository.GetEmolyee(1));
            return Json(_employeeRepository.GetEmolyee(1));

        }

        public IActionResult Details()
        {
            List<Employee> employeeLista = new List<Employee>();
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmolyee(1),
                PageHeader = "Details"
            };

        

        
            return View(homeDetailsViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
