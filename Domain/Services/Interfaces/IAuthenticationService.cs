using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task LoginAsync(Usuario usuario);
        Task LogoutAsync();
    }
}