using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Autoregister.Sample.Business
{
    [DependencyRegistration]
    public class FirstBusiness
    {
        public string GetValueUppercase(string value)
        {
            return value.ToUpperInvariant();
        }
    }
}
