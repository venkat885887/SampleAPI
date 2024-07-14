using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmpAddressDto
    {
        public int? EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public int? EmpSalary { get; set; }
        public string EmpAddress { get; set; }
    }
}
