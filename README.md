
# DependendyInjection.Autoregister
Dependency injection autoregistration with attribute


| Package | Build | Version |
|-|-|-|
|DependencyInjection.Autoregister.Abstraction|[![Build Status](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_apis/build/status/DependencyInjection.Autoregister.Abstraction?branchName=master)](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_build/latest?definitionId=25&branchName=version2.0)|[0.0.1-preview01](https://www.nuget.org/packages/DependencyInjection.Autoregister.Abstraction)|
|DependencyInjection.Autoregister.Providers.Autofac|||
|DependencyInjection.Autoregister.Providers.ServiceCollection|[![Build Status](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_apis/build/status/DependencyInjection.Autoregister.Providers.ServiceCollection?branchName=master)](https://dev.azure.com/grasseelsp/DependencyInjection.Autoregister/_build/latest?definitionId=25&branchName=version2.0)|[0.0.1-preview01](https://www.nuget.org/packages/DependencyInjection.Autoregister.Providers.ServiceCollection)|
|DependencyInjection.Autoregister.Providers.Unity|||


## DependencyInjection.Autoregister.Abstraction
Provide an helper and attribute. Helper return all type must be register and load in specific assembly, after you can implement your own registration system.

## Install package
[![NuGet version](https://badge.fury.io/nu/DependencyInjection.Autoregister.Abstraction.svg)](https://badge.fury.io/nu/DependencyInjection.Autoregister.Abstraction)

Package Manager
```
PM> Install-Package DependencyInjection.Autoregister.Abstraction -Version 0.0.1-preview01
```
DotNet CLI
```
dotnet add package DependencyInjection.Autoregister.Abstraction --version 0.0.1-preview01
```

# Use attribute for register
### Simple Usage
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

### Simple Usage with lifetime
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
### Simple Usage with name
```csharp
[DependencyRegistration("MyName")]
public class SecondBusiness
{
    public string GetValueUppercase(string value)
    {
        return value.ToUpperInvariant();
    }
}
```

### Simple Usage with interface
```csharp
public interface IThirdBusiness
{
    string GetValueUppercase(string value);
}

[DependencyRegistration]
public class ThirdBusiness : IThirdBusiness
{
    public string GetValueUppercase(string value)
    {
        return value.ToUpperInvariant();
    }    
}
```

### Simple Usage with multiple interface
```csharp
public interface IThirdBusiness
{
    string GetValueUppercase(string value);
}

public interface ISecondBusiness
{
    string GetValueLower(string value);
}

[DependencyRegistration]
public class ThirdBusiness : IThirdBusiness, ISecondBusiness
{ 
    public string GetValueUppercase(string value)
    {
        return value.ToUpperInvariant();
    } 

    public string GetValueLower(string value)
    {
        return value.ToLowerInvariant();
    }     
}
```


# DependencyInjection.Autoregister.Providers.ServiceCollection	
It's a implementation for autoregister on IServiceCollection provider.

## Install package
[![NuGet version](https://badge.fury.io/nu/DependencyInjection.Autoregister.Providers.ServiceCollection.svg)](https://badge.fury.io/nu/DependencyInjection.Autoregister.Providers.ServiceCollection)

Package Manager
```
PM> Install-Package DependencyInjection.Autoregister.Providers.ServiceCollection -Version 0.0.1-preview01
```
DotNet CLI
```
dotnet add package DependencyInjection.Autoregister.Providers.ServiceCollection --version 0.0.1-preview01
```

# Autoregister on ASPNET Core
```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        services.AddAutoRegister();
    }
}
```

# Autoregister without ASPNET Core
```csharp
var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
services.AddAutoRegister(Assembly.GetAssembly(typeof(MyAssemblyName)));
var provider = services.BuildServiceProvider();
var resolveService = provider.GetService<FirstClass>();
```