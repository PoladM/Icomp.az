using IComp.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace IComp.ServiceExtentions
{
    public static class ExceptionHandlingService
    {
        public static void ExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = 500;
                    string message = "Internal server error!";

                    if (contextFeatures != null)
                    {
                        message = contextFeatures.Error.Message;

                        if (contextFeatures.Error is ItemNotFoundException)
                        {
                            statusCode = 404;
                        }
                        else if (contextFeatures.Error is RecordDuplicatedException)
                        {
                            statusCode = 409;
                        }
                    }

                    context.Response.StatusCode = statusCode;

                    string responseStr = JsonConvert.SerializeObject(new
                    {
                        message = message,
                        code = statusCode
                    });

                    await context.Response.WriteAsync(responseStr);
                });
            });
        }
    }
}
