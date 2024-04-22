using Core.Entities;
using Core.Enumerations;
using Core.Exceptions;
using Core.Interfaces.Repository;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infraestructure.Filters
{
    public class ActionsApiFilter : IAsyncActionFilter
    {
        public readonly IAdminInterfaces _adminInterfaces;
        private IHttpContextAccessor _accessor;
        public ActionsApiFilter(IAdminInterfaces adminInterfaces, IHttpContextAccessor accessor)
        {
            _adminInterfaces = adminInterfaces;
            _accessor = accessor;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await OnActionExecuting(context);
            await next();
        }
        public async Task OnActionExecuting(ActionExecutingContext filterContext)
        {
            int idUserSession = _adminInterfaces.utilsFunctionsRepository.GetIdUserToken(filterContext.HttpContext.Request.Headers.Authorization);
            if (idUserSession != 0)
            {
                string urlRequest = _accessor.HttpContext.Request.Path;

                var arrReplaceUrlRequest = urlRequest.ToCharArray();
                string replaceUrlRequest = "";
                int cont = 0;
                foreach (char i in arrReplaceUrlRequest)
                {
                    if (i.ToString() == "/")
                    {
                        cont = cont + 1;

                    }
                    if (cont != 3)
                    {
                        replaceUrlRequest = replaceUrlRequest + i.ToString();
                    }
                }
                try
                {
                    switch (_accessor.HttpContext.Request.Method)
                    {
                        case "GET":
                            if (urlRequest.Contains("GetAll"))
                            {
                                await validatePermiss(idUserSession, EnumPermissions.getall, replaceUrlRequest);
                                
                            }
                            else if (urlRequest.Contains("GetById"))
                            {
                                await validatePermiss(idUserSession, EnumPermissions.get, replaceUrlRequest);
                            }
                            break;

                        case "POST":
                             await validatePermiss(idUserSession, EnumPermissions.create, replaceUrlRequest);
                            break;

                        case "PUT":
                            await validatePermiss(idUserSession, EnumPermissions.update, replaceUrlRequest);
                            break;
                        case "DELETE":
                            await validatePermiss(idUserSession, EnumPermissions.delete, replaceUrlRequest);
                            break;
                    }


                }
                catch (Exception e)
                {
                    LogException logException = new LogException();
                    logException.Message = $"Data consult error : {e.Message}";
                    logException.Name = "Internal Server Error in ActionsApiFilter funtion OnActionExecuting";

                    InternalServerErrorBusinessExceprions ex = new InternalServerErrorBusinessExceprions(logException);
                    throw ex;
                }
            }
        }

        protected async Task validatePermiss(int idUser, EnumPermissions enumPermissions,string nameService)
        {
            var user = _adminInterfaces.userRepository.GetById(idUser);
            if (user != null)
            {
                if (!await _adminInterfaces.userRepository.validatePermissions(user.Result != null ? user.Result.id : idUser, (int)enumPermissions, nameService))
                {
                    LogException logException = new LogException();
                    logException.Message = $"El usuario no tiene permisos";
                    logException.Name = "Internal Server Error in ActionsApiFilter funtion validatePermiss";
                    UnauthorizedBusinessException ex = new UnauthorizedBusinessException(logException);

                    throw ThrowException(ex, 400, ex.Message);
                }
            }
        }
        protected BaseException ThrowException(BaseException exception, int idEvent, string message)
        {
            return exception;
        }
    }
}
