namespace IncomeTax.API.Domain.Services.Communication
{
    /// <summary>
    /// Classe base para respostas a solicitações de serviços.
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// Indica se a solicitação foi bem-sucedida ou não.
        /// </summary>
        public bool Success { get; protected set; }

        /// <summary>
        /// Mensagem de retorno, quando for o caso.
        /// </summary>
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}