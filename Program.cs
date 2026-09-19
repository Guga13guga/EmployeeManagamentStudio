using EmployeeManagamentStudio.UI;

/// <summary>
/// Main entry point of the application. It provides a console-based user interface for managing employees, departments, and companies.
/// </summary>

var employeeUi = new EmployeeUI();
var departmentUi = new DepartmentUi();
var companyUi = new CompanyUI();

while (true)
{
    Console.Clear();
    Console.WriteLine("Main Menu");
    Console.WriteLine("1. Manage Employees");
    Console.WriteLine("2. Manage Departments");
    Console.WriteLine("3. Manage Companies");
    Console.WriteLine("4. Exit");
    Console.Write("Select an option: ");

    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            employeeUi.RunEmployeeUi();
            Console.ResetColor();
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            departmentUi.RunDepartamentUi();
            Console.ResetColor();
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Green;
            companyUi.RunCompanyUi();
            Console.ResetColor();
            break;
        case "4":
            Console.WriteLine("Exiting... Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;
    }
}
