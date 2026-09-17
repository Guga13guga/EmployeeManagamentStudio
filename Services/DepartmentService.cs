using EmployeeManagamentStudio.Models;

namespace EmployeeManagamentStudio.Services;

/// <summary>
/// Service class for managing departments, providing methods to retrieve, filter, sort, update, and delete department data.
/// </summary>
public class DepartmentService : GenericService<Deparment>
{
    public DepartmentService(string filePath) : base(filePath)
    {

    }

    public List<Deparment> GetDepartmentsByCompanyId(Guid companyId)
    {
        return _items.Where(d => d.CompanyId == companyId).ToList();
    }

    public List<Employee> GetEmployeeByDepartment(Guid departmentId)
    {
        var department = _items.FirstOrDefault(d => d.Id == departmentId);
        return department?.Employees ?? new List<Employee>();
    }

    public List<Deparment> SortDepartmentsByName()
    {
        var deparments = _items.OrderBy(i => i.Name);
        return deparments.ToList();
    }

    public List<Deparment> FillterDeparmentByName(string name)
    {
        var deparments = _items.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return deparments.ToList();
    }

    public List<Deparment> FillterDeparmentByDescription(string description)
    {
        var deparments = _items.Where(i => i.Description != null && i.Description.Contains(description, StringComparison.OrdinalIgnoreCase));
        return deparments.ToList();
    }

    public void DeleteDepartment(Guid departmentId)
    {
        var department = _items.FirstOrDefault(d => d.Id == departmentId);
        if (department != null)
        {
            _items.Remove(department);
            SaveChanges();
        }
    }

    public void DeleteDepartmentsByCompanyId(Guid companyId)
    {
        var departmentsToDelete = _items.Where(d => d.CompanyId == companyId).ToList();
        foreach (var department in departmentsToDelete)
        {
            _items.Remove(department);
        }
        SaveChanges();
    }



    public void UpdateDepartment(Deparment updatedDepartment)
    {
        var department = _items.FirstOrDefault(d => d.Id == updatedDepartment.Id);
        if (department != null)
        {
            department.Name = updatedDepartment.Name;
            department.Description = updatedDepartment.Description;
            department.CompanyId = updatedDepartment.CompanyId;
            SaveChanges();
        }
    }
}
