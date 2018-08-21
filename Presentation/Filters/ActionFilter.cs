using Domain.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class ActionFilter : IResultFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActionFilter(IUnitOfWork unitOfWork) => this._unitOfWork = unitOfWork;

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //nothing to do..
        }

        public void OnResultExecuted(ResultExecutedContext context)
            => _unitOfWork.CommitAsync();
    }
}