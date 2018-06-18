using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Autoregister.Sample.Business
{
    public interface IThirdBusiness
    {
    }

    [DependencyRegistration]
    public partial class ThirdBusiness : IThirdBusiness
    {
    }
}
