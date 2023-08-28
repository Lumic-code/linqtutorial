
using LINQTutorial;

internal class Program
{
    public static readonly List<Employee> employees = new();
    public static readonly List<Project> projects = new();

    private static void Main(string[] args)
    {
        InitializeEmployees();
        InitializeProjects();
        FindEmployeeStartWithM();
        FindEmployeeStartWithJ();
        OrderEmployeeByNameAsc();
        OrderEmployeeByNameDesc();
        OrderByID();
        EmployeeTake();
        EmployeeSkip();
        EmployeeGroupBy();
        EmployeeFirst();
        EmployeeFirstOrDefault();
        GetEmployeeProj();
        GetAllProj();
    }

    public static void InitializeEmployees()
    {
        employees.Add(new Employee
        {
            EmployeeID = 1,
            EmployeeName = "John",
            ProjectID = 100
        });

        employees.Add(new Employee
        {
            EmployeeID = 2,
            EmployeeName = "Mary",
            ProjectID = 101
        });

        employees.Add(new Employee
        {
            EmployeeID = 3,
            EmployeeName = "Mike",
            ProjectID = 102
        });
    }

    public static void InitializeProjects()
    {
        projects.Add(new Project
        {
            ProjectID = 100,
            ProjectName = "Project 1"
        });

        projects.Add(new Project
        {
            ProjectID = 101,
            ProjectName = "Project 2"
        });
    }

    //Query syntax
    public static void FindEmployeeStartWithM()
    {
        var empoyeeM = from employee in employees
            where employee.EmployeeName.StartsWith("M")
            select employee.EmployeeName;

        Console.WriteLine("Where in employeeM-------");
        foreach (var result in empoyeeM)
        {
            Console.WriteLine(result);
        }
    }

    //Method syntax
    public static void FindEmployeeStartWithJ()
    {
        var empoyeeJ = employees.Where(e => e.EmployeeName.StartsWith("J"));
        Console.WriteLine("Where in employeeJ-------");
        foreach (var res in empoyeeJ)
        {
            Console.WriteLine(res.EmployeeName);
        }

        Console.WriteLine('\n');
    }

    //LINQ ORDERBY
    public static void OrderEmployeeByNameAsc()
    {
        //Query syntax
        var employeeOrderByNameAsc = from employee in employees
                                     orderby employee.EmployeeName
                                     select employee.EmployeeName;

        //Method syntax
        var employeeOrderByNameAsc2 = employees.OrderBy(e => e.EmployeeName);
        Console.WriteLine("Order by ascending in querySyntax2------");
        foreach (var item in employeeOrderByNameAsc)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Order by ascending in methodSyntax2-----");
        foreach (var item in employeeOrderByNameAsc2)
        {
            Console.WriteLine(item.EmployeeName);
        }

        Console.WriteLine('\n');
    }

    //LINQ ORDERBYDESC
    public static void OrderEmployeeByNameDesc()
    {
        //Query syntax
        var employeeOrderByNameDesc = from employee in employees
                                      orderby employee.EmployeeName descending
                                      select employee.EmployeeName;

        //Method syntax
        var employeeOrderByNameDesc2 = employees.OrderByDescending(e => e.EmployeeName);
        Console.WriteLine("Order by descending in querySyntax3------");
        foreach (var item in employeeOrderByNameDesc)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Order by descending in methodSyntax3-----");
        foreach (var item in employeeOrderByNameDesc2)
        {
            Console.WriteLine(item.EmployeeName);
        }

        Console.WriteLine('\n');
    }   

    //LINQ THENBY
    public static void OrderByID()
    {
         //QuerySyntax
         var querySyntax4 = from employee in employees
                                orderby employee.ProjectID, employee.EmployeeName descending
                                select employee;

        //MethodSyntax
        var methodSyntax4 = employees.OrderBy(e => e.ProjectID).ThenByDescending(e => e.EmployeeName);
       
        Console.WriteLine("Then by  in querySyntax4------");
        foreach (var item in querySyntax4)
        {
            Console.WriteLine(item.EmployeeName + ":" + item.ProjectID);
        }
        Console.WriteLine("Then by  in methodSyntax4-------");
        foreach (var item in methodSyntax4)
        {
            Console.WriteLine(item.EmployeeName + ":" + item.ProjectID);
        }
        Console.WriteLine('\n');
    }

    //LINQ TAKE
    public static void EmployeeTake()
    {
        //QuerySyntax
        var querySyntax5 = (from employee in employees
                            select employee).Take(2);

        var methodSyntax5 = employees.Take(2);

        Console.WriteLine("Take in querySyntax-----");
        foreach (var item in querySyntax5)
        {
            Console.WriteLine(item.EmployeeName);
        }

        Console.WriteLine("Take in methodSyntax-----");
        foreach (var item in methodSyntax5)
        {
            Console.WriteLine(item.EmployeeName);
        }

        Console.WriteLine('\n');
    }

    //LINQ SKIP
    public static void EmployeeSkip()
    {
        //QuerySyntax
        var querySyntax6 = (from employee in employees
                            select employee).Skip(2);

        var methodSyntax6 = employees.Skip(2);

        Console.WriteLine("Skip in querySyntax-----");
        foreach (var item in querySyntax6)
        {
            Console.WriteLine(item.EmployeeName);
        }

        Console.WriteLine("Skip in methodSyntax-----");
        foreach (var item in methodSyntax6)
        {
            Console.WriteLine(item.EmployeeName);
        }

        Console.WriteLine('\n');
    }

    //LINQ GROUPBY
    public static void EmployeeGroupBy()
    {
        //querySyntax
        var querySyntax7 = from employee in employees
                           group employee by employee.ProjectID;

        //methodSyntax
        var methodSyntax7 = employees.GroupBy(e => e.ProjectID);

        Console.WriteLine("Group in querySyntax------");
        foreach (var item in querySyntax7)
        {
            Console.WriteLine(item.Key + ":" + item.Count());
        }

        Console.WriteLine("Group in methodSyntax------");
        foreach (var item in methodSyntax7)
        {
            Console.WriteLine(item.Key + ":" + item.Count());
        }

        Console.WriteLine('\n');
    }

    // LINQ FIRST
    public static void EmployeeFirst()
    {
        //querySyntax
        var querySyntax8 = (from employee in employees
                            //where employee.EmployeeName.StartsWith("M")
                            select employee).First();
        //methodSyntax
        var methodSyntax8 = employees
                            //.where(e => e.EmployeeName.StartsWith("M"))
                           .First();

        Console.WriteLine("First in querySyntax-------");
        if (querySyntax8 != null)
        {
            Console.WriteLine(querySyntax8.EmployeeName);
        }

        Console.WriteLine("First in methodSyntax-------");
        if (methodSyntax8 != null)
        {
            Console.WriteLine(methodSyntax8.EmployeeName);
        }

    }

    // LINQ FIRSTORDEFAULT
    public static void EmployeeFirstOrDefault()
    {
        //querySyntax
        var querySyntax9 = (from employee in employees
                            //where employee.EmployeeName.StartsWith("M")
                            select employee).FirstOrDefault();

        var methodSyntax9 = employees
                            //.where(e => e.EmployeeName.StartsWith("M"))
                           .FirstOrDefault();

        Console.WriteLine("FirstOrDefault in querySyntax-------");
        if (querySyntax9 != null)
        {
            Console.WriteLine(querySyntax9.EmployeeName);
        }

        Console.WriteLine("FirstOrDefault in methodSyntax-------");
        if (methodSyntax9 != null)
        {
            Console.WriteLine(methodSyntax9.EmployeeName);
        }

        Console.WriteLine('\n');
    }

    // LINQ JOIN
    public static void GetEmployeeProj()
    {
        //querySyntax
        var querySyntax10 = from employee in employees
                            join project in projects
                            on employee.ProjectID equals project.ProjectID
                            select new
                            {
                                 employee.EmployeeName,
                                 project.ProjectName
                            };
        var methodSyntax10 = employees.Join(projects,
                                             e => e.ProjectID,
                                             p => p.ProjectID,
                                             (e, p) => new
                                             { e.EmployeeName, p.ProjectName });

        Console.WriteLine("Join in querySyntax-------");
        foreach (var item in querySyntax10)
        {
            Console.WriteLine(item.EmployeeName + ":" + item.ProjectName);
        }

        Console.WriteLine("Join in methodSyntax-------");
        foreach (var item in methodSyntax10)
        {
            Console.WriteLine(item.EmployeeName + ":" + item.ProjectName);
        }

        Console.WriteLine('\n');
    }

    // LINQ LEFT JOIN
    public static void GetAllProj()
    {
        //querySyntax
        var querySyntax11 = from employee in employees
                            join project in projects 
                            on employee.ProjectID equals project.ProjectID into employeeGroup
                            from project in employeeGroup.DefaultIfEmpty()
                            select new
                            {
                                employee.EmployeeName,
                                ProjectName = project?.ProjectName ?? "NULL"
                            };

        //methodSyntax
        var methodSyntax11 = employees.GroupJoin(projects,
                             e => e.ProjectID, p => p.ProjectID,
                             (e, p) => new { e, p })
                             .SelectMany(z => z.p.DefaultIfEmpty(),
                              (a, b) => new  {
                               a.e.EmployeeName, ProjectName = b?.ProjectName ?? "NULL"
                               });
        Console.WriteLine("Left Join in querySyntax-------");
        foreach (var item in querySyntax11)
        {
            Console.WriteLine(item.EmployeeName + ":" + item.ProjectName);
        }

        Console.WriteLine("Left Join in methodSyntax-------");
        foreach (var item in methodSyntax11)
        {
              Console.WriteLine(item.EmployeeName + ":" + item.ProjectName);
        }

        Console.WriteLine('\n');
    }
}
