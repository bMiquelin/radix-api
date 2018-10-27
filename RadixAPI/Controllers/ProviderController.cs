using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RadixAPI.Helper;
using RadixAPI.Providers;

namespace RadixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get() => EnumExtensions.EnumDictionary<ProviderEnum>().Select(e => new { Id = e.Key, Name = e.Value }).ToArray();
    }
}