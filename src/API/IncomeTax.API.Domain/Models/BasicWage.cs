namespace IncomeTax.API.Domain.Models
{
    /// <summary>
    /// Representa o salário mínimo.
    /// </summary>
    public class BasicWage
    {
        /// <summary>
        /// Código do registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Valor do salário mínimo.
        /// </summary>
        public decimal Value { get; set; }
    }
}