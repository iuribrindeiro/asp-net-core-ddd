using Data.Context;
using Domain.UnitOfWork.Interfaces;

namespace Data.UnitOfWor
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext applicationContext) => _applicationContext = applicationContext;

        public void Commit()
        {
            _applicationContext.SaveChanges();
        }
    }
}