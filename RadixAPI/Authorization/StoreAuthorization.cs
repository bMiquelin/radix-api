using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RadixAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RadixAPI.Authorization
{
    public class StoreAuthorization : IAuthorizationFilter
    {
        private readonly RadixAPIContext ctx;
        public StoreAuthorization(RadixAPIContext ctx)
        {
            this.ctx = ctx;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var api_key_header = context.HttpContext.Request.Headers["API_KEY"].ToString();
            var store_id_header = context.HttpContext.Request.Headers["STORE_ID"].ToString();


            if (!Guid.TryParse(api_key_header, out var api_key) || !Guid.TryParse(store_id_header, out var store_id))
            {
                context.Result = new ContentResult { StatusCode = (int)HttpStatusCode.Unauthorized };
                return;
            }
            
            var store = ctx.Stores.FirstOrDefault(s => s.Id == store_id);
            if (store.API_KEY != api_key)
            {
                context.Result = new ContentResult { StatusCode = (int)HttpStatusCode.Forbidden };
                return;
            }
        }
    }
}
