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