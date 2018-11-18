namespace IncomeTax.API.Client.Resources
{
    /// <summary>
    /// Recurso para envio de dados de um contribuinte.
    /// </summary>
    public class TaxpayerResource
    {
        /// <summary>
        /// Código do contribuinte.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do contribuinte.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CPF do contribuinte.
        /// </summary>
        public long CPF { get; set; }

        /// <summary>
        /// Número de dependentes do contribuinte.
        /// </summary>
        public short NumberOfDependents { get; set; }

        /// <summary>
        /// Renda bruta mensal do contribuinte.
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