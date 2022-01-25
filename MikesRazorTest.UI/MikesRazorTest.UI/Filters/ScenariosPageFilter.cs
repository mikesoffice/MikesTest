namespace MRT.UI.Filters;

using Genus.OpsPortal.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ScenariosPageFilter : IAsyncPageFilter
{
    private readonly IMediator _mediator;

    public ScenariosPageFilter(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        await Task.CompletedTask;
    }
    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        var result = context.HandlerInstance;
        if (result is PageModel pageResult)
        {
            pageResult.ViewData["ScenarioData"] = (await _mediator.Send(new GetScenariosLookupQuery())).Data;
        }

        await next.Invoke();
    }
}
