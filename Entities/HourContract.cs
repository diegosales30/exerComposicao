namespace ExerComposicao.Entities
{
  class HourContract
  {

    //atributos
    public DateTime Date { get; set; }
    public double ValuePerHour { get; set; }
    public int Hours { get; set; }

    //construtor
    public HourContract(DateTime date, double valuePerHour, int hours)
    {
      Date = date;
      ValuePerHour = valuePerHour;
      Hours = hours;
    }

    //metodo
    public double TotalValue()
    {
      return Hours * ValuePerHour;
    }

  }
}