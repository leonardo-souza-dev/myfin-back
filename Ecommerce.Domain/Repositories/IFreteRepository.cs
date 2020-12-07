namespace Ecommerce.Domain.Repositories
{
    public interface IFreteRepository
    {
        decimal? Calcular(string cep);
    }
}