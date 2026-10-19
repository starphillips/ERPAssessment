namespace ERPAssessment.Models;

public class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Responsibility> Responsibilities { get; set; } = new();
}
