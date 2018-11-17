namespace IncomeTax.API.Client.Resources
{
    public class TaxpayerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long CPF { get; set; }
        public short NumberOfDependents { get; set; }
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