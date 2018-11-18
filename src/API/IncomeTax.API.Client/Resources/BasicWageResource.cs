using System.ComponentModel.DataAnnotations;

namespace IncomeTax.API.Client.Resources
{
    /// <summary>
    /// Recurso que representa os dados de salário mínimo.
    /// </summary>
    public class BasicWageResource
    {
        /// <summary>
        /// Valor do salário mínimo.
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, 10000)]
        public decimal Value { get; set; }
    }
}