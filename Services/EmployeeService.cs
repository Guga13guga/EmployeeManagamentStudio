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

    /// <summary>
    /// Sorts employees by their first name in ascending order.
    /// </summary>
    /// <returns></returns>
    public List<Employee> SortEmployeesByName()
    {
        var employees = _items.OrderBy(i => i.FirstName);
        return employees.ToList();
    }

    /// <summary>
    /// Sorts employees by their first name in descending order.
    /// </summary>
    /// <returns>A list of employees sorted by first name in descending order.</returns>
    public List<Employee> SortEmployeesByNameDescending()
    {
        var employees = _items.OrderByDescending(i => i.FirstName);
        return employees.ToList();
    }

    /// <summary>
    /// Sorts employees by their last name in ascending order.
    /// </summary>
    /// <returns></returns>
    public List<Employee> SortEmployeesByLastName()
    {
        var employees = _items.OrderBy(i => i.LastName);
        return employees.ToList();
    }

    /// <summary>
    /// Sorts employees by their last name in descending order.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<Employee> FillterEmployeeByName(string name)
    {
        var employees = _items.Where(i => i.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || i.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
        return employees.ToList();
    }

    /// <summary>
    /// Deletes an employee from the collection based on the provided employee ID. If the employee is found, it is removed from the collection and changes are saved.
    /// </summary>
    /// <param name="employeeId"></param>
    public void DeleteEmployee(Guid employeeId)
    {
        var employee = _items.FirstOrDefault(e => e.Id == employeeId);
        if (employee != null)
        {
            _items.Remove(employee);
            SaveChanges();
        }
    }

    /// <summary>
    ///Deletes all employees associated with a specific department ID. It finds all employees belonging to the given department and removes them from the collection, then saves the changes.
    /// </summary>
    /// <param name="departmentId"></param>
    public void DeleteEmployeesByDepartmentId(Guid departmentId)
    {
        var employeesToDelete = _items.Where(e => e.DepartmentId == departmentId).ToList();
        foreach (var employee in employeesToDelete)
        {
            _items.Remove(employee);
        }
        SaveChanges();
    }

    /// <summary>
    /// Updates an existing employee's information based on the provided updated employee object. It finds the employee with the matching ID and updates its properties, then saves the changes.
    /// </summary>
    /// <param name="updatedEmployee"></param>
    public void UpdateEmployee(Employee updatedEmployee)
    {
        var employee = _items.FirstOrDefault(e => e.Id == updatedEmployee.Id);
        if (employee != null)
        {
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            SaveChanges();
        }
    }

    /// <summary>
    /// Retrieves a list of employees associated with a specific department ID. It filters the collection of employees to find those belonging to the given department and returns them as a list.
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns></returns>
    public List<Employee> GetEmployeesByDepartmentId(Guid departmentId)
    {
        return _items.Where(e => e.DepartmentId == departmentId).ToList();
    }
}
