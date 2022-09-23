using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeDAL;

namespace APIusing_EmployeeDALDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository = null;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public string AddNwEmployee(Employee employee)
        {

            return _repository.AddNewEmployee(employee);
        }
        [HttpGet]
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _repository.GetAllEmployees();
        }
        [HttpGet("{id}")]
        public Employee GetEmploById(int id)
        {
          return   _repository.GetEmployeeById(id);
        }
        [HttpPut]
        public string UpdateEmployee(Employee employee)
        {

            return _repository.Updateemployee(employee);
        }
        [HttpDelete]
        public string DeleteEmployee(int id)
        {

            return _repository.Deleteemployee(id);
        }
    }
}
