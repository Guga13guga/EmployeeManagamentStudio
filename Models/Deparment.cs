namespace EmployeeManagamentStudio.Models;

/// <summary>
/// Represents a department within a company, including its name, description, associated company, and employees.
/// </summary>
public class Deparment : BaseModel
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public Guid CompanyId { get; set; }

    public List<Employee>? Employees { get; set; }
}
