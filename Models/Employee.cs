namespace EmployeeManagamentStudio.Models;

/// <summary>
/// Represents an employee within the organization, including their personal details and associated department.
/// </summary>
public class Employee : BaseModel
{
    public required string FirstName { get; set; }

    public required string  LastName { get; set; }

    public required string Email { get; set; }

    public string? Phone { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Fax { get; set; }

    public Guid DepartmentId { get; set; }
}
