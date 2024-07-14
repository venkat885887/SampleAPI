using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AddEmploeeDto
    {
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public int? EmpGender { get; set; }
        public DateTime? EmpDOB { get; set; }
        public DateTime? EmpDOJ { get; set; }
        public int? EmpSalary { get; set; }
        public string EmpAddress { get; set; }
        public int? EmpStatus { get; set; }
        public int? EmpDept { get; set; }
        public int? ManagerId { get; set; }
        public string EmailAddress { get; set; }
    }
}
