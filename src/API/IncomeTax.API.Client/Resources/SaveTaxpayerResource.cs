using System.ComponentModel.DataAnnotations;

namespace IncomeTax.API.Client.Resources
{
    public class SaveTaxpayerResource
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public long CPF { get; set; }
        
        [Required]
        [Range(0, short.MaxValue)]
        public short NumberOfDependents { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal GrossIncome { get; set; }
    }
}