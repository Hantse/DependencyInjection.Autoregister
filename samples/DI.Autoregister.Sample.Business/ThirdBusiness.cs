using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Autoregister.Sample.Business
{
    public interface IThirdBusiness
    {
    }

    [DependencyRegistration]
    public class ThirdBusiness : IThirdBusiness
    {
    }
}
