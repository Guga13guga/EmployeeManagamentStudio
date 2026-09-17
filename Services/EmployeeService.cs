using EmployeeManagamentStudio.Models;

namespace EmployeeManagamentStudio.Services;

public class EmployeeService : GenericService<Employee>
{
    public EmployeeService(string filePath) : base(filePath)
    {
    }

    public List<Employee> SortEmployeesByName()
    {
        var employees = _items.OrderBy(i => i.FirstName);
        return employees.ToList();
    }

    public List<Employee> FillterEmployeeByName(string name)
    {
        var employees = _items.Where(i => i.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || i.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
        return employees.ToList();
    }

    public void DeleteEmployee(int employeeId)
    {
        var employee = _items.FirstOrDefault(e => e.Id == employeeId);
        if (employee != null)
        {
            _items.Remove(employee);
            SaveChanges();
        }
    }

    public void DeleteEmployeesByDepartmentId(int departmentId)
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
        if (employee != null)
        {
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            SaveChanges();
        }
    }

    public List<Employee> GetEmployeesByDepartmentId(int departmentId)
    {
        return _items.Where(e => e.DepartmentId == departmentId).ToList();
    }
}
