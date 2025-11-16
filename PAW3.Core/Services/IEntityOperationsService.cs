namespace PAW3.Core.Services
{
    public interface IEntityOperationsService
    {
        decimal Average(decimal[] values);
        string EliminarEspacios(string texto);
        IEnumerable<decimal> SumEach(List<decimal> values, decimal num);
    }

    public class EntityOperationsService : IEntityOperationsService
    {
        public decimal Average(decimal[] values)
        {
            return values.Length == 0 ? 0 : values.Average();
        }

        public IEnumerable<decimal> SumEach(List<decimal> values, decimal num)
        {
            var results = new List<decimal>();
            values.ForEach(x =>
            {
                results.Add(x + num);
            });
            return results;
        }

        public string EliminarEspacios(string texto)
        {
            return texto.Replace(" ", "");
        }
    }
}
