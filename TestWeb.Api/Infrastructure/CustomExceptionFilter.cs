using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using TestWeb.Infrastructure.ExceptionPolicy;

namespace TestWeb.Api.Infrastructure
{
    
    
        public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                if (context.Exception is CustomException)
                {
                    context.Response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                }
            }
        }


    

}
