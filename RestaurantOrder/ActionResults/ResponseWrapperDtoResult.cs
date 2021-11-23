using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Services.Contracts;

namespace RestaurantOrder.ActionResults
{
   
    
        public class ResponseWrapperDtoResult<T> : ActionResult
        {
            public ResponseWrapperDtoResult(ResponseWrapperDto<T> wrapper)
            {
                Wrapper = wrapper ?? throw new ArgumentNullException(nameof(wrapper));
            }

            private ResponseWrapperDto<T> Wrapper { get; }

            public override void ExecuteResult(ActionContext context)
            {
                GetResult().ExecuteResult(context);
            }

            public override Task ExecuteResultAsync(ActionContext context)
            {
                return GetResult().ExecuteResultAsync(context);
            }

            private ActionResult GetResult() =>
                Wrapper.Success
                    ? new OkObjectResult(Wrapper.Data)
                    : new ObjectResult(new { Wrapper.Errors })
                        { StatusCode = (int?)Wrapper.StatusCode ?? StatusCodes.Status400BadRequest };
        }
    
}
