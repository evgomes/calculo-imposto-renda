using System.ComponentModel.DataAnnotations;

namespace IncomeTax.API.Client.Resources
{
    /// <summary>
    /// Recurso para gravação de dados de um contribuine do imposto de renda.
    /// </summary>
    public class SaveTaxpayerResource
    {
        /// <summary>
        /// Nome do contribuinte.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        /// <summary>
        /// CPF do contribuinte.
        /// </summary>
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string CPF { get; set; }
        
        /// <summary>
        /// Número de dependentes do contribuinte.
        /// </summary>
        [Required]
        [Range(0, short.MaxValue)]
        public short NumberOfDependents { get; set; }

        /// <summary>
        /// Renda bruta mensal do contribuinte.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal MonthlyGrossIncome { get; set; }
    }
}