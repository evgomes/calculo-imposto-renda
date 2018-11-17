namespace IncomeTax.API.Domain.Models
{
    /// <summary>
    /// Representa o salário mínimo.
    /// </summary>
    public class BasicWage
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
    }
}