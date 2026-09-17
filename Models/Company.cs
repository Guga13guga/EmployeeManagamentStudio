namespace EmployeeManagamentStudio.Models;

public class Company : BaseModel
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public List<Deparment>? Deparments { get; set; }
}
