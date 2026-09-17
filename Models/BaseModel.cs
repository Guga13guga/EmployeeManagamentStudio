namespace EmployeeManagamentStudio.Models;

/// <summary>
/// Base model class that provides a unique identifier for derived models.
/// </summary>
public abstract class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
