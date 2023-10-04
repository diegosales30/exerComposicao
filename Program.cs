using System;
using System.Globalization;
using ExerComposicao.Entities;
using ExerComposicao.Entities.Enums;

namespace ExerComposicao
{
   class Program
   {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter department's name: ");
      string depName = Console.ReadLine();

      Console.WriteLine("Enter worker data: ");
      Console.WriteLine("Name: ");
      string name = Console.ReadLine();

      Console.WriteLine("Level (Junior/MidLevel/Senior): ");
      WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

      Console.WriteLine("Base salary: ");
      double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
      //apos pegar os dados digitados e salvar em variaveis momentaneas
      //instanciar as classes e associar

      Department dept = new Department(depName);
      Worker worker = new Worker(name, level, baseSalary, dept);

      Console.WriteLine("How many contracts to this worker? ");
      int n = int.Parse(Console.ReadLine());

      for (int i = 0; i < n; i++)
      {
        Console.WriteLine($"Enter #{i} contract data:");

        Console.Write($"Date (DD/MM/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Value per hour: ");
        double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write($"Duration (hours): ");
        int hours = int.Parse(Console.ReadLine());

        HourContract contract = new HourContract(date, valuePerHour, hours);
        worker.AddContract(contract);
      }
      Console.WriteLine();
      Console.Write("Enter month and year to calculate income (MM/YYYY): ");
      string monthYear = Console.ReadLine();

      int month = int.Parse(monthYear.Substring(0, 2));
      int year = int.Parse(monthYear.Substring(3));

      Console.WriteLine("Name: " + worker.Name);
      Console.WriteLine("Department: " + worker.Department.Name);
      Console.WriteLine("Income for: " + monthYear + ": " + worker.Income(year, month));
    }
   }
}