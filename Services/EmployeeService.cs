using ERPAssessment.Models;

namespace ERPAssessment.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = new()
    {
        new PermanentEmployee
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

    public Employee? Delete(int id)
    {

        var match = _employees.FirstOrDefault(x => x.Id == id);
        if (match == null)
        {
            return null;
        }
        
        _employees.Remove(match);

        return match;
    }

    public Employee? Update(int id, Employee employee)
    {
        var existing = _employees.FirstOrDefault(x => x.Id == id);
        if (existing == null)
        {
            return null;
        }

        existing.Name = employee.Name;
        existing.Email = employee.Email;
        existing.JoiningDate = employee.JoiningDate;
        existing.Department = employee.Department;
        existing.Role = employee.Role;

        if (existing is PermanentEmployee existingEmployee && employee is PermanentEmployee updatedEmployee)
        {
            existingEmployee.Salary = updatedEmployee.Salary;
        }
        else if (existing is ContractEmployee existingContractor && employee is ContractEmployee updatedContractor)
        {
            existingContractor.HourlyRate = updatedContractor.HourlyRate;
            existingContractor.HoursWorked = updatedContractor.HoursWorked;
        }

        return existing;
    }

    public List<Employee> GetEmployeesByDepartmentID(int departmentID)
    {
        List<Employee> employeesInDepartment = new List<Employee>();

        foreach (Employee employee in _employees)
        {
            if (employee.Department == null)
            {
                continue;
            }
            else if (departmentID == employee.Department.Id)
            {
                employeesInDepartment.Add(employee);
            }
            
        }
        return employeesInDepartment;
    }

}
