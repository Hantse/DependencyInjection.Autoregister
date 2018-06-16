using System;

namespace DI.Autoregister.Sample.Business
{
    [DependencyRegistration]
    public class SecondBusiness
    {
        public string GetValueUppercase(string value)
        {
            return value.ToUpperInvariant();
        }
    }
}
