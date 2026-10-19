
using System.ComponentModel.DataAnnotations;

namespace ERPAssessment.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public DateTime JoiningDate { get; set; }

    public decimal Salary
    { 
        get => field;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Salary), "Salary cannot be 0 or below");
            }
            field = value;
        } 
    }

    public Department? Department { get; set; }

    public Role? Role { get; set; }
}
