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
}
