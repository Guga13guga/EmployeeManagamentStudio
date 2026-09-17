namespace EmployeeManagamentStudio.Models;

public class Deparment : BaseModel
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public int CompanyId { get; set; }

    public List<Employee>? Employees { get; set; }
}
