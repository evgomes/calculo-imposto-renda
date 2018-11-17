using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Services.Communication.Taxpayers
{
    public class TaxpayerResponse : BaseResponse
    {
        public Taxpayer Taxpayer { get; set; }

        private TaxpayerResponse(bool success, string message, Taxpayer taxpayer) : base(success, message)
        {
            this.Success = success;
            this.Message = message;
            this.Taxpayer = taxpayer;
        }

        public static TaxpayerResponse CreateSuccess(Taxpayer taxpayer)
        {
            return new TaxpayerResponse(true, "Sucesso.", taxpayer);
        }

        public static TaxpayerResponse CreateFail(string message)
        {
            return new TaxpayerResponse(false, message, null);
        }
    }
}