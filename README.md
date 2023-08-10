# ISO.csharp

A library that provides access to ISO standards, including ISO 639 (language codes), ISO 3166 (country codes), and ISO 4217 (currency codes).


[![NuGet version (ISOLib)](https://img.shields.io/nuget/v/ISOLib.svg?style=flat-square)](https://www.nuget.org/packages/ISOLib/)
[![ISOLib](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml)

### Usage

   ```csharp
Language lang = Languages.Collection["eng"];
if (lang == Languages.ENG || lang == Languages.KIR)
      Console.WriteLine(lang);

Country[] countries = Countries.Collection.Where(c => c.Name[0] == 'A').ToArray();
foreach (Country country in countries)
{
      Language[] langs = country.GetLanguages();
      Currency[] currencies = country.GetCurrencies();
      string langsColumn = string.Join(',', langs.Select(l => l.Name));
      string currenciesColumn = string.Join(',', currencies.Select(l=>l.Alpha3));
      Console.WriteLine($"{country.Alpha2};{country.Name};{currenciesColumn};{langsColumn}");
}

Currency[] supportedCurrencies = Currencies.FilterCurrencies("USD", "KGS", "RUB");
foreach (var currency in supportedCurrencies)
{
      Console.WriteLine(currency);   
}
   ```

## Models

### Country model

  ```csharp
class Country
{
      public string Alpha2 { get; }
      public string Alpha3 { get; }
      public string Name { get; }
      public string Name2 { get; }
      public string NativeName { get; }
      public string Capital { get; }
      public string CountryCode { get; }
      public string Continent { get; }
      public string ContinentAlpha2 { get; }
      public string Wiki { get; }
      public string Flag { get; }
      public int[] Phones { get; }
      public string[] Currencies { get; }
      public string[] Languages { get; }
}
   ```
   
### Language model

  ```csharp
class Language
{
      public string Alpha2 { get; }
      public string Alpha3 { get; }
      public string Name { get; }
      public string Name2 { get; }
      public string NativeName { get; }
      public string Family { get; }
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
