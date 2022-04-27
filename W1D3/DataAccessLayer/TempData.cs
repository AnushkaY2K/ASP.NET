using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TempData
    {
        public static List<EmployeeDto> Data { get; set; } = new List<EmployeeDto>();
    }
}
