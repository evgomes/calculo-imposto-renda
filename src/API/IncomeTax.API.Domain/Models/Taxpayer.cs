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

        /// <summary>
        /// Número de dependentes. Impacta no cálculo da taxa do imposto de renda, pois ocasiona descontos.
        /// </summary>
        /// <value></value>
        public short NumberOfDependents { get; set; }

        /// <summary>
        /// Renda bruta mensal.
        /// </summary>
        public decimal MonthlyGrossIncome { get; set; }

        /// <summary>
        /// Alíquota do imposto de renda.
        /// </summary>
        public decimal IncomeTaxRatePercentage { get; set; }

        /// <summary>
        /// Total de imposto a pagar.
        /// </summary>
        public decimal TotalIncomeTax { get; set; }
    }
}