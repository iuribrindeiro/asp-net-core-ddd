using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Services.Interfaces
{
    public interface IEnviadorTokenCadastroService
    {
        Task EnviarTokenAsync(Usuario usuario);
    }
}