using ERPAssessment.Models;
using ERPAssessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERPAssessment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public ActionResult<List<Employee>> GetAll()
    {
        return Ok(_employeeService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = _employeeService.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> Create(Employee employee)
    {
        var created = _employeeService.Add(employee);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Employee> Edit(int id, Employee employee)
    {
        var edited = _employeeService.Update(id, employee);
        if (edited == null)
        {
            return NotFound();
        }
        return Ok(edited);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Employee> Delete(int id)
    {
        var deleted = _employeeService.Delete(id);
        if (deleted == null)
        {
            return NotFound();
        }
        return Ok(deleted);
    }

    [HttpGet("department/{departmentID:int}")]
    public ActionResult<List<Employee>> GetEmployeesByDepartmentID(int departmentID)
    {
        var departmentEmployees = _employeeService.GetEmployeesByDepartmentID(departmentID);
        return Ok(departmentEmployees);
    }

}
