using Bus.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class ActionFilter : IActionFilter
    {
        private readonly IMediator _mediator;

        public ActionFilter(IMediator mediator) => _mediator = mediator;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //nothing to do...
        }

        public void OnActionExecuted(ActionExecutedContext context) 
            => _mediator.Publish(new CommitEvent());
    }
}