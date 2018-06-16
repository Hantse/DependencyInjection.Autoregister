# DI.Autoregister
Dependency injection autoregistration with attribute

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

# Use the registration on Startup
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    services.AddAutoRegister();
}
```


    