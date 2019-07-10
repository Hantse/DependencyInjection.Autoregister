using DependencyInjection.Autoregister.Abstraction.Attributes;

namespace DependencyInjection.Autoregister.Sample.Business
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
