using System.Threading;
using System.Threading.Tasks;
using Bus.Events;
using Domain.UnitOfWork.Interfaces;
using MediatR;

namespace Bus.Handlers
{
    public class CommitHandler : INotificationHandler<CommitEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public Task Handle(CommitEvent notification, CancellationToken cancellationToken)
        {
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }
    }
}