namespace EmployeeManagamentStudio.Models;

/// <summary>
/// Represents a company with its details and associated departments.
/// </summary>
public class Company : BaseModel
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public List<Deparment>? Deparments { get; set; }
}
