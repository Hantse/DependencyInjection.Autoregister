[![Build Status](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_apis/build/status/DependencyInjection.Autoregister.Abstration-version2.0?branchName=version2.0)](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_build/latest?definitionId=25&branchName=version2.0)

|   |   |   |   |   |
|---|---|---|---|---|
|   |   |   |   |   |
|   |   |   |   |   |
|   |   |   |   |   |

# DependendyInjection.Autoregister
Dependency injection autoregistration with attribute

## Install package
[![NuGet version](https://badge.fury.io/nu/DI.Autoregister.svg)](https://badge.fury.io/nu/DI.Autoregister)
```
PM> Install-Package DI.Autoregister -Version 1.2.0
```
Or in dotnet cli
```
dotnet add package DI.Autoregister --version 1.2.0
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
