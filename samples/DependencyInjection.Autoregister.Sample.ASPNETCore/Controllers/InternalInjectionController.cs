using DependencyInjection.Autoregister.Sample.Business;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DependencyInjection.Autoregister.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalInjectionController : ControllerBase
    {

        private readonly FirstBusiness _firstBusiness;

        public InternalInjectionController(FirstBusiness firstBusiness)
        {
            _firstBusiness = firstBusiness ?? throw new ArgumentNullException(nameof(firstBusiness));
        }

        [HttpGet("{value}")]
        public ActionResult<string> Get(string value)
        {
            return _firstBusiness.GetValueUppercase(value);
        }
    }
}
