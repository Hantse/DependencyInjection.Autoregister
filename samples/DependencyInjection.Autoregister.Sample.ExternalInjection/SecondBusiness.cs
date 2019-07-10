using DependencyInjection.Autoregister.Abstraction.Attributes;

namespace DependencyInjection.Autoregister.Sample.ExternalInjection
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
