using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task LoginAsync(Usuario usuario);
        Task LogoutAsync();
    }
}