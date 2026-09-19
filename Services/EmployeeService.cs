using EmployeeManagamentStudio.Models;

namespace EmployeeManagamentStudio.Services;

/// <summary>
/// Represents a service for managing employee data, providing functionalities such as sorting, filtering, updating, and deleting employees.
/// </summary>
public class EmployeeService : GenericService<Employee>
{
    public EmployeeService(string filePath) : base(filePath)
    {
    }

    public List<Employee> SortEmployeesByName()
    {
        return _items.OrderBy(i => i.FirstName).ToList();
    }

    public List<Employee> SortEmployeesByNameDescending()
    {
        return _items.OrderByDescending(i => i.FirstName).ToList();
    }

    public List<Employee> SortEmployeesByLastName()
    {
        return _items.OrderBy(i => i.LastName).ToList();
    }

    public List<Employee> FillterEmployeeByName(string name)
    {
        return _items
            .Where(i => i.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase)
                || i.LastName.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void DeleteEmployee(Guid employeeId)
    {
        var employee = _items.FirstOrDefault(e => e.Id == employeeId);
        if (employee != null)
        {
            _items.Remove(employee);
            SaveChanges();
        }
    }

    public void DeleteEmployeesByDepartmentId(Guid departmentId)
    {
        var employeesToDelete = _items.Where(e => e.DepartmentId == departmentId).ToList();
        foreach (var employee in employeesToDelete)
        {
            _items.Remove(employee);
        }

        SaveChanges();
    }

    public void UpdateEmployee(Employee updatedEmployee)
    {
        var employee = _items.FirstOrDefault(e => e.Id == updatedEmployee.Id);
        if (employee == null)
        {
            return;
        }

        employee.FirstName = updatedEmployee.FirstName;
        employee.LastName = updatedEmployee.LastName;
        employee.Email = updatedEmployee.Email;
        employee.Phone = updatedEmployee.Phone;
        employee.PostalCode = updatedEmployee.PostalCode;
        employee.Country = updatedEmployee.Country;
        employee.Fax = updatedEmployee.Fax;
        employee.DepartmentId = updatedEmployee.DepartmentId;

        SaveChanges();
    }

    public List<Employee> GetEmployeesByDepartmentId(Guid departmentId)
    {
        return _items.Where(e => e.DepartmentId == departmentId).ToList();
    }
}
