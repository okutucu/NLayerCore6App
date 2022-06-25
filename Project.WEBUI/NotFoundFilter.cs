using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.WEBUI
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> services)
        {
            _service = services;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            int id = (int)idValue;

            bool anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
            }

            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{typeof(T)}.Name({id}) not found");


            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
