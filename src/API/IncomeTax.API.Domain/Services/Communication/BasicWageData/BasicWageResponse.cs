using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Services.Communication.BasicWageData
{
    /// <summary>
    /// Resposta a uma solicitação ao serviço de salário mínimo.
    /// </summary>
    public class BasicWageResponse : BaseResponse
    {
        /// <summary>
        /// Dados de salário mínimo retornados.
        /// </summary>
        public BasicWage BasicWage { get; set; }

        private BasicWageResponse(bool success, string message, BasicWage basicWage) : base(success, message)
        {
            this.Success = success;
            this.Message = message;
            this.BasicWage = basicWage;
        }

        public static BasicWageResponse CreateSuccess(BasicWage basicWage)
        {
            return new BasicWageResponse(true, "Sucesso.", basicWage);
        }

        public static BasicWageResponse CreateFail(string message)
        {
            return new BasicWageResponse(false, message, null);
        }
    }
}