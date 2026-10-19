namespace ERPAssessment.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime JoiningDate { get; set; }

    public decimal Salary { get; set; }

    public Department? Department { get; set; }

    public Role? Role { get; set; }
}
