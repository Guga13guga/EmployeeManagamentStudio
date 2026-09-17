using EmployeeManagamentStudio.Consts;
using EmployeeManagamentStudio.Models;
using EmployeeManagamentStudio.Services;

namespace EmployeeManagamentStudio.UI;

/// <summary>
/// Represents the user interface for managing employees, providing options to add, list, update, delete, sort, and filter employees.
/// </summary>
public class EmployeeUI
{
    private readonly EmployeeService _employeeManager;
    private readonly DepartmentService _departmentManager;

    public EmployeeUI()
    {
        _employeeManager = new EmployeeService(FilePaths.EmployeesStoragePath);
        _departmentManager = new DepartmentService(FilePaths.DepartmentsStoragePath);
    }

    public void RunEmployeeUi()
    {
        while (true)
        {
            Console.WriteLine("Employee Management");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Sort Employees");
            Console.WriteLine("6. Filter Employees");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    ListEmployees();
                    break;
                case "3":
                    UpdateEmployee();
                    break;
                case "4":
                    DeleteEmployee();
                    break;
                case "5":
                    SortEmployees();
                    break;
                case "6":
                    FilterEmployees();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (input == "7")
            {
                Console.Clear();
                break;
            }
        }
    }

    private void FilterEmployees()
    {
        Console.WriteLine("Filter Employees");
        Console.WriteLine("Enter a name to filter by:");
        var name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name.");
            return;
        }

        var filteredEmployees = _employeeManager.FillterEmployeeByName(name);
        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine($"- {employee.FirstName} {employee.LastName} ({employee.Email})");
        }
    }

    private void SortEmployees()
    {
        Console.WriteLine("Sort Employees");
        Console.WriteLine("asc or desc:");
        var input = Console.ReadLine();

        List<Employee>? sortedEmployees;
        if (input == "asc")
        {
            sortedEmployees = _employeeManager.SortEmployeesByName();
        }
        else if (input == "desc")
        {
            sortedEmployees = _employeeManager.SortEmployeesByNameDescending();
        }
        else
        {
            Console.WriteLine("Invalid option.");
            sortedEmployees = null;
        }

        if(sortedEmployees is not null)
        {
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"- {employee.FirstName} {employee.LastName} ({employee.Email})");
            }
        }
    }

    private void DeleteEmployee()
    {
        Console.WriteLine("Delete Employee");
        Console.WriteLine("Enter the employee ID to delete:");
        var input = Console.ReadLine();
        if (!Guid.TryParse(input, out Guid employeeId))
        {
            Console.WriteLine("Invalid employee ID.");
            return;
        }
        var employee = _employeeManager.GetAll().FirstOrDefault(e => e.Id == employeeId);
        if (employee is null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        _employeeManager.DeleteEmployee(employeeId);
        _employeeManager.SaveChanges();
        Console.WriteLine("Employee deleted successfully.");
    }

    private void UpdateEmployee()
    {
        Console.WriteLine("Update Employee");
        Console.WriteLine("enter the employee ID to update:");
        var input = Console.ReadLine();
        if (!Guid.TryParse(input, out Guid employeeId))
        {
            Console.WriteLine("Invalid employee ID.");
            return;
        }
        var employee = _employeeManager.GetAll().FirstOrDefault(e => e.Id == employeeId);
        if (employee is null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }
        Console.WriteLine($"Current Name: {employee.FirstName}");
        Console.WriteLine("Enter new name (leave empty to keep current):");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
        {
            employee.FirstName = name;
        }
        Console.WriteLine($"current surname: {employee.LastName}");
        Console.WriteLine("Enter new surname (leave empty to keep current):");
        var surname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(surname))
        {
            employee.LastName = surname;
        }
        Console.WriteLine($"Current Email: {employee.Email}");
        Console.WriteLine("Enter new email (leave empty to keep current):");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email))
        {
            employee.Email = email;
        }
        Console.WriteLine("Enter new department (leave empty to keep current):");
        var department = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(department))
        {
            var departmentObj = _departmentManager.GetAll().FirstOrDefault(d => d.Name.Equals(department, StringComparison.OrdinalIgnoreCase));
            if (departmentObj is null)
            {
                Console.WriteLine("Department not found. Please add the department first.");
                return;
            }
            employee.DepartmentId = departmentObj.Id;
        }
        Console.WriteLine("Enter new country (leave empty to keep current):");
        var country = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(country))
        {
            employee.Country = country;
        }
        Console.WriteLine("Enter new fax number (leave empty to keep current):");
        var fax = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(fax))
        {
            employee.Fax = fax;
        }
        Console.WriteLine("Enter new phone number (leave empty to keep current):");
        var phone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phone))
        {
            employee.Phone = phone;
        }
        Console.WriteLine("Enter new postal code (leave empty to keep current):");
        var postalCode = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(postalCode))
        {
            employee.PostalCode = postalCode;
        }
        Console.WriteLine("Employee updated successfully.");
        _employeeManager.UpdateEmployee(employee);
        _employeeManager.SaveChanges();
    }

    private void ListEmployees()
    {
        Console.WriteLine("List Employees");
        var employees = _employeeManager.GetAll();
        foreach (var employee in employees)
        {
            Console.WriteLine($"- {employee.FirstName} {employee.LastName} ({employee.Email})");
        }
    }

    private void AddEmployee()
    {
        Console.WriteLine("Add Employee");
        Console.WriteLine("Enter employee name:");
        var name = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Employee name cannot be empty.");
            return;
        }
        Console.WriteLine("Enter employee email:");
        var email = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Employee email cannot be empty.");
            return;
        }
        Console.WriteLine("Enter employee department:");
        var department = Console.ReadLine();
        var departmentObj = _departmentManager.GetAll().FirstOrDefault(d => d.Name.Equals(department, StringComparison.OrdinalIgnoreCase));
        if (departmentObj is null)
        {
            Console.WriteLine("Department not found. Please add the department first.");
            return;
        }

        Console.WriteLine("enter your surname:");
        var surname = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(surname))
        {
            Console.WriteLine("Employee surname cannot be empty.");
            return;
        }

        Console.WriteLine("enter your country:");
        var country = Console.ReadLine();
        Console.WriteLine("enter your fax number:");
        var fax = Console.ReadLine();
        Console.WriteLine("enter your phone number:");
        var phone = Console.ReadLine();
        Console.WriteLine("enter your postal code:");
        var postalCode = Console.ReadLine();
        var employee = new Employee
        {
            FirstName = name,
            LastName = surname,
            Email = email,
            DepartmentId = departmentObj.Id,
            Country = country,
            Fax = fax,
            Phone = phone,
            PostalCode =postalCode,
        };
       
        _employeeManager.Add(employee);
    }
}
