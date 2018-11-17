namespace IncomeTax.API.Domain.Repositories
{
    public interface ITaxpayerRepository
    {
         Task<IEnumerable<Taxpayer>> ListBy
    }
}