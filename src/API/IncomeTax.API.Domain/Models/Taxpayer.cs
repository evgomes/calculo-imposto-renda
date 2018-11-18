namespace IncomeTax.API.Domain.Models
{
    /// <summary>
    /// Representa um contribuinte do imposto de renda.
    /// </summary>
    public class Taxpayer
    {
        /// <summary>
        /// Código do contribuinte.
        /// </summary>
        /// <remarks>Poderia ter optado por usar o CPF como código, porém prefiro manter um padrão de geração automática dos códigos.</remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome do contribuinte.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// CPF do contribuinte.
        /// </summary>
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