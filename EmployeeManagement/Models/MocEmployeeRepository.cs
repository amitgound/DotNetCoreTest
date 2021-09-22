using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MocEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();

        public MocEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){id =1,Name = "Amit",Email ="amit92@gmail.com",Department ="IT" },
                new Employee(){id =2,Name = "Vidya",Email ="vidya92@gmail.com",Department = "IT" },
                new Employee(){id =3,Name = "Avinash",Email ="avinash92@gmail.com",Department = "IT" }
            };
        }


        public Employee GetEmolyee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.id == Id);
        }
    }
}
