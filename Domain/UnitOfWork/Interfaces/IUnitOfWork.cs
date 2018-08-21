using System.Threading.Tasks;

namespace Domain.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}