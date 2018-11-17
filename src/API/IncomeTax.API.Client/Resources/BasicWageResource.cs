using System.ComponentModel.DataAnnotations;

namespace IncomeTax.API.Client.Resources
{
    public class BasicWageResource
    {
        [Required]
        [Range(1, 10000)]
        public decimal Value { get; set; }
    }
}