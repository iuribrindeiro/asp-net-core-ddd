using Bus.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class ActionFilter : IResultFilter
    {
        private readonly IMediator _mediator;

        public ActionFilter(IMediator mediator) => _mediator = mediator; 
            

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //nothing to do..
        }

        public void OnResultExecuted(ResultExecutedContext context)
            => _mediator.Publish(new CommitEvent());
    }
}