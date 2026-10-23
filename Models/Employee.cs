
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPAssessment.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "employmentType")]
[JsonDerivedType(typeof(PermanentEmployee), "permanent")]
[JsonDerivedType(typeof(ContractEmployee), "contract")]
public abstract class Employee
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public DateTime JoiningDate { get; set; }

    public Department? Department { get; set; }

    public Role? Role { get; set; }

    public abstract decimal CalculatePay();
}

public class PermanentEmployee: Employee
{
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
    public override decimal CalculatePay()
    {
        return Salary;
    }
}

public class ContractEmployee: Employee
{
    public decimal HourlyRate { get; set; }

    public decimal HoursWorked {get; set; }
    public override decimal CalculatePay()
    {
         return HourlyRate * HoursWorked;
    }
}