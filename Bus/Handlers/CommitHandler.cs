using System.Threading;
using System.Threading.Tasks;
using Bus.Events;
using Domain.UnitOfWork.Interfaces;
using MediatR;

namespace Bus.Handlers
{
    public class CommitHandler : AsyncRequestHandler<CommitEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        protected override Task Handle(CommitEvent request, CancellationToken cancellationToken)
        {
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }
    }
}