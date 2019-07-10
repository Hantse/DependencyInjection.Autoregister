[![Build Status](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_apis/build/status/Hantse.DependencyInjection.Autoregister?branchName=master)](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_build/latest?definitionId=23&branchName=master)

# DependendyInjection.Autoregister
Dependency injection autoregistration with attribute

## Install package
```
```

# Use attribute on class
```csharp
[DependencyRegistration]
public class SecondBusiness
{
    public string GetValueUppercase(string value)
    {
        return value.ToUpperInvariant();
    }
}
```

```csharp
[DependencyRegistration(ServiceRegistrationType.SINGLETON)]
public class SecondBusiness
{
    public string GetValueUppercase(string value)
    {
        return value.ToUpperInvariant();
    }
}
```

```csharp
public interface IThirdBusiness
{
}

[DependencyRegistration]
public class ThirdBusiness : IThirdBusiness
{    
}
```

The first interface is use for DI registration.

# Use the registration on Startup with IServiceCollection provider

## Install package

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddAutoRegister();
    ...
}
```
