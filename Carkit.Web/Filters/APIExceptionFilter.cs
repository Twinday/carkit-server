using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Carkit.Services.Services.Exceptions;

namespace Carkit.Web.Filters
{
    /// <summary>
    /// Фильтр для обработки исключений <see cref="System.Exception"/>.
    /// </summary>
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private const string CONTROLLER_ROUTE_KEY = "controller";

        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Инициализация.
        /// </summary>
        public ApiExceptionFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Выполняется асинхронно, если при обработке запроса было выброшено исключений <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="context">Текущий контекст исключения.</param>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            // Обработка сообщений об ошибках уровня Сервиса
            if (context.Exception is ServiceException serviceException)
            {
                var serviceError = new
                {
                    Message = serviceException.Message,
                };

                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                context.Result = new JsonResult(serviceError);
            }
            // Unhandled exception
            else
            {
                var apiError = new
                {
                    Message = context.Exception.GetBaseException().Message,
#if DEBUG
                    Detail = context.Exception.StackTrace
#endif
                };

                // создать новый Scope, чтобы откатить все изменения в данных до появления исключения и работать с ним
                using (var serviceScope = _serviceProvider.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                }

                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(apiError);
            }

            await base.OnExceptionAsync(context);
        }

    }
}
