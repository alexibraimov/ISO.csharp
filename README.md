# ISO.csharp

A library that provides access to ISO standards, including ISO 639 (language codes), ISO 3166 (country codes), and ISO 4217 (currency codes).


[![NuGet version (ISOLib)](https://img.shields.io/nuget/v/ISOLib.svg?style=flat-square)](https://www.nuget.org/packages/ISOLib/)
[![ISOLib](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml)

### Usage

   ```csharp
        Language lang = ISO.LanguageCollection["eng"];
        Console.WriteLine(lang);

        foreach (Country country in ISO.CountryCollection.Where(c => c.Alpha3[0] == 'A'))
        {
            Console.WriteLine(country);
        }

        string currencies = string.Join('\n', ISO.CurrencyCollection.OrderBy(x => x.Name).Select(x => $"{x.Name}; {x.Alpha3}; {x.MinorUnit}"));
        Console.WriteLine(currencies);
   ```

## Models

### Country model

  ```csharp
class Country
{
    string Name { get; }
    string Alpha2 { get; }
    string Alpha3 { get; }
    string CountryCode { get; }
    string ISO3166_2 { get; }
    string Region { get; }
    string SubRegion { get; }
    string IntermediateRegion { get; }
    string RegionCode { get; }
    string SubRegionCode { get; }
    string IntermediateRegionCode { get; }
}
   ```
   
### Language model

  ```csharp
class Language
{
    string Name { get; }
    string Alpha2 { get; }
    string Alpha3 { get; }
    string CountryCode { get; }
    string Family { get; }
    string NativeName { get; }
}
   ```
### Currency model

  ```csharp
class Currency
{
    string Name { get; }
    string Alpha2 { get; }
    string Alpha3 { get; }
    string Number { get; }
    int MinorUnit { get; }
}
   ```
