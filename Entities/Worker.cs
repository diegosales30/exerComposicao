using System.Collections.Generic;
using ExerComposicao.Entities.Enums;

namespace ExerComposicao.Entities
{
  class Worker
  {

    //atributos
    public string Name { get; set; }
    public WorkerLevel Level { get; set; }

    public double BaseSalary { get; set;}
    //fazendo composição, associoação, a classe worker tem suas props e a de department
    public Department Department { get; set;}

    //ja começa instanciada, para evitar de inciar nula, -> new List<>
    public List<HourContract> Contracts { get; set; } = new List<HourContract>();

    //construtores
    public Worker()
    {

    }
    public Worker(string name, WorkerLevel level, double baseSalary, Department department)
    {
      Name       = name;
      Level      = level;
      BaseSalary = baseSalary;
      Department = department;
    }

    //metodos
    public void AddContract(HourContract contract)
    {
      Contracts.Add(contract);
    }
    public void RemoveContract(HourContract contract)
    {
      Contracts.Remove(contract);
    }

    public double Income(int year, int month)
    {
      double sum = BaseSalary;
      foreach(HourContract contract in Contracts)
      {
        if(contract.Date.Year == year && contract.Date.Month == month)
        {
          sum += contract.TotalValue();
        }
      }
      return sum;
    }
  }
}