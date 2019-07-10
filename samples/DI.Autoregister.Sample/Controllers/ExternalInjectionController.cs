using DependencyInjection.Autoregister.Sample.Business;
using DependencyInjection.Autoregister.Sample.ExternalInjection;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DependencyInjection.Autoregister.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalInjectionController : ControllerBase
    {
        private readonly SecondBusiness _secondBusiness;

        public ExternalInjectionController(SecondBusiness secondBusiness)
        {
            _secondBusiness = secondBusiness ?? throw new ArgumentNullException(nameof(secondBusiness));
        }

        [HttpGet("{value}")]
        public ActionResult<string> Get(string value)
        {
            return _secondBusiness.GetValueUppercase(value);
        }
    }
}
