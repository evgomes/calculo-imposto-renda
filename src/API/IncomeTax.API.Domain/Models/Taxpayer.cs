namespace IncomeTax.API.Domain.Models
{
    /// <summary>
    /// Representa um contribuinte do imposto de renda.
    /// </summary>
    public class Taxpayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long CPF { get; set; }
        public short NumberOfDependents { get; set; }

        /// <summary>
        /// Renda bruta mensal.
        /// </summary>
        public decimal MonthlyGrossIncome { get; set; }
    }
}