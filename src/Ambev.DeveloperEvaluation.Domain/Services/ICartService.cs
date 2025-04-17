using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public interface ICartService
    {
        void CalcularTotais(Cart cart);
    }
}
