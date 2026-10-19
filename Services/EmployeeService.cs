using ERPAssessment.Models;

namespace ERPAssessment.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = new()
    {
        new Employee
        {
            Id = 1,
            Name = "Alex Green",
            Email = "alex.green@company.local",
            JoiningDate = DateTime.Today.AddYears(-1),
            Salary = 28000,
            Department = new Department { Id = 1, Name = "Engineering" },
            Role = new Role
            {
                Id = 1,
                Name = "Junior Developer",
                Responsibilities = new List<Responsibility>
                {
                    new Responsibility { Id = 1, Description = "Fix small defects" },
                    new Responsibility { Id = 2, Description = "Implement simple API changes" }
                }
            }
        }
    };

    public List<Employee> GetAll()
    {
        return _employees;
    }

    public Employee? GetById(int id)
    {
        return _employees.FirstOrDefault(x => x.Id == id);
    }

    public Employee Add(Employee employee)
    {
        employee.Id = _employees.Count == 0 ? 1 : _employees.Max(x => x.Id) + 1;
        _employees.Add(employee);
        return employee;
    }
}
