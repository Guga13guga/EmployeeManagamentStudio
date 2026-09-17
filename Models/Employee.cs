namespace EmployeeManagamentStudio.Models;

public class Employee : BaseModel
{
    public required string FirstName { get; set; }

    public required string  LastName { get; set; }

    public required string Email { get; set; }

    public string? Phone { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Fax { get; set; }

    public int DepartmentId { get; set; }
}
