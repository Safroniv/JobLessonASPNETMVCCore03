
ConcreateEmployeCreater concreateEmploye = new ConcreateEmployeCreater();
BaseEmployee[] baseEmployees = new BaseEmployee[10];
Random random = new Random();



for (int i = 1; i <= 10; i++)
{
    Array values = Enum.GetValues(typeof(EmployeeType));
    EmployeeType randomEmploye = (EmployeeType)values.GetValue(random.Next(values.Length));
    Console.WriteLine($"{concreateEmploye.CreateBaseEmployee(randomEmploye)}\t {randomEmploye}");
}


public class GenerateFCs
{
    public static string FCsGenerator()
    {
        Random random = new Random();
        int i = random.Next(7, 9);
        int j = random.Next(7, 9);
        int k = random.Next(7, 9);
        return $"{GenerateName(i)}\t {GenerateName(j)}\t {GenerateName(k)}\t";
    }
    public static string GenerateName(int len)
    {
        Random r = new Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2;
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }
        return Name;
    }
}


public abstract class BaseEmployee
{
    public Employee Employee { get; set; }
    public EmployeeType TypeEmployee { get; set; }
    public abstract decimal MonthPrice();

    public BaseEmployee(EmployeeType typeEmployee)
    {
        TypeEmployee = typeEmployee;
    }
    public abstract void SetBaseEmployee(object typeEmployee);

    public abstract void GetBaseEmployee(object typeEmployee);

    public override string ToString()
    {
        return $"{GenerateFCs.FCsGenerator()} \t Ставка: {MonthPrice()} руб.";
    }
}
public enum EmployeeType
{
    hourlyRateEmploye,
    momthlyRateEmployee
}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronomic { get; set; }

    public Employee(string firstName, string lastName, string patronomic)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronomic = patronomic;
    }

}

abstract class BaseEmployeeCreater
{
    public BaseEmployee CreateBaseEmployee(EmployeeType employeeType)
    {
        BaseEmployee baseEmployee = CreateBaseEmployeeInstance(employeeType);
        return baseEmployee;
    }
    protected abstract BaseEmployee CreateBaseEmployeeInstance(EmployeeType employeeType);
}
class ConcreateEmployeCreater : BaseEmployeeCreater
{
    protected override BaseEmployee CreateBaseEmployeeInstance(EmployeeType employeeType)
    {
        switch (employeeType)
        {
            case EmployeeType.hourlyRateEmploye:
                return new EmployeeTimePrice(EmployeeType.hourlyRateEmploye);
            case EmployeeType.momthlyRateEmployee:
                return new EmployeeFixPrice(EmployeeType.momthlyRateEmployee);
            default:
                return null;
        }
    }
}
class EmployeeTimePrice : BaseEmployee
{
    public EmployeeTimePrice(EmployeeType typeEmployee) : base(typeEmployee)
    {
    }

    public override void GetBaseEmployee(object typeEmployee)
    {
        throw new NotImplementedException();
    }

    public override decimal MonthPrice()
    {
        decimal hourlyRate = new Random().Next(500, 1500);
        decimal price = 20.8M * 8 * hourlyRate;
        return price;
    }

    public override void SetBaseEmployee(object typeEmployee)
    {
        throw new NotImplementedException();
    }
}

class EmployeeFixPrice : BaseEmployee
{
    public EmployeeFixPrice(EmployeeType typeEmployee) : base(typeEmployee)
    {
    }

    public override void GetBaseEmployee(object typeEmployee)
    {
        throw new NotImplementedException();
    }

    public override decimal MonthPrice()
    {
        decimal monthRate = new Random().Next(50000, 100000);
        decimal price = monthRate;
        return price;
    }

    public override void SetBaseEmployee(object typeEmployee)
    {
        throw new NotImplementedException();
    }
}