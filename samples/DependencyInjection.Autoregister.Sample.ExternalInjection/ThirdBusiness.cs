using DependencyInjection.Autoregister.Abstraction.Attributes;

namespace DependencyInjection.Autoregister.Sample.ExternalInjection
{
    public interface IThirdBusiness
    {
    }

    [DependencyRegistration]
    public partial class ThirdBusiness : IThirdBusiness
    {
    }
}
