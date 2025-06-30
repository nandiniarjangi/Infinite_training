using System;
using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static List<Employee> employees = new List<Employee>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n*****Employee Management Menu ******");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddEmployee(); 
                            break;
                    case 2: ViewEmployees(); 
                            break;
                    case 3: SearchEmployee(); 
                            break;
                    case 4: UpdateEmployee(); 
                            break;
                    case 5: DeleteEmployee(); 
                            break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice.Please Try again."); 
                            break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void AddEmployee()
    {
        try
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();
            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());

            employees.Add(new Employee { Id = id, Name = name, Department = dept, Salary = salary });
            Console.WriteLine("Employee added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in adding employee: {ex.Message}");
        }
    }

    static void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        foreach (var emp in employees)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
        }
    }

    static void SearchEmployee()
    {
        Console.Write("Enter Employee ID to search: ");
        int id = int.Parse(Console.ReadLine());
        var emp = employees.Find(e => e.Id == id);
        if (emp != null)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID to update: ");
        int id = int.Parse(Console.ReadLine());
        var emp = employees.Find(e => e.Id == id);
        if (emp != null)
        {
            Console.Write("Enter new Name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter new Department: ");
            emp.Department = Console.ReadLine();
            Console.Write("Enter new Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        var emp = employees.Find(e => e.Id == id);
        if (emp != null)
        {
            employees.Remove(emp);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}

