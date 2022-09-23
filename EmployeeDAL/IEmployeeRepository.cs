using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public interface IEmployeeRepository
    {
        string AddNewEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);
        
        string Updateemployee(Employee employee);
        string Deleteemployee(int id );
    }
}
