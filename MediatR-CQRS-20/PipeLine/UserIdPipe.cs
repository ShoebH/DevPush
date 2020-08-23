using Management;
using Management.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_CQRS_20.PipeLine
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private HttpContext httpContext;

        public UserIdPipe(IHttpContextAccessor accessor)
        {
            httpContext = accessor.HttpContext;
        }

        public async Task<TOut> Handle(
            
            TIn request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TOut> next)
        {
            //var userId = httpContext.User.Claims
            //    .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))
            //    .Value;

            if (request is BaseRequest br)
                          {
                                br.UserId = "XYZ";
                            }

            var result = await next();

            if (result is Response<User> userResponse)
            {
                userResponse.Data.FirstName += " CHECKEED";
            }

            return result;

            //return next();
            //throw new NotImplementedException();
        }
    }
    //  public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    //    {
    //        private HttpContext httpContext;

    //        public UserIdPipe(IHttpContextAccessor accessor)
    //        {
    //            httpContext = accessor.HttpContext;
    //        }

    //        public async Task<TOut> Handle(
    //            TIn request,
    //            CancellationToken cancellationToken,
    //            RequestHandlerDelegate<TOut> next)
    //        {
    //            var userId = httpContext.User.Claims
    //                .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))
    //                .Value;

    //            if (request is BaseRequest br)
    //            {
    //                br.UserId = "XYZ";
    //            }

    //            return next();
    //        //    var result = await next();

    //        //    if (result is Response<Car> carResponse)
    //        //    {
    //        //        carResponse.Data.Name += " CHECKEED";
    //        }

    //        //    return result;
    //        //}

    //        //public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
    //        //{
    //        //    throw new NotImplementedException();
    //        //}
    //    }
}
