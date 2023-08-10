# ISO.csharp

A library that provides access to ISO standards, including ISO 639 (language codes), ISO 3166 (country codes), and ISO 4217 (currency codes).


[![NuGet version (ISOLib)](https://img.shields.io/nuget/v/ISOLib.svg?style=flat-square)](https://www.nuget.org/packages/ISOLib/)
[![ISOLib](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ISOLib.svg)](https://www.nuget.org/packages/ISOLib)

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
    public string Name { get; }
    public string Alpha2 { get; }
    public string Alpha3 { get; }
    public string Number { get; }
    public int MinorUnit { get; }
}
   ```
# List of Countries
| Alpha-2 | Alpha-3 | Name               | Capital    | Continent | Phone Codes | Currency Codes | Languages  | Flag | Wikipedia |
|---------|---------|--------------------|------------|-----------|-------------|----------------|------------|------|-----------|
| AF      | AFG     | Afghanistan        | Kabul      | Asia      | +93         | AFN            | ps, uz, tk | 🇦🇫  | [Link](https://en.wikipedia.org/wiki/ISO_3166-2:AF) |
| AX      | ALA     | Åland Islands     | Mariehamn  | Europe    | +358        | EUR            | sv         | 🇦🇽  | [Link](https://en.wikipedia.org/wiki/ISO_3166-2:AX) |
| AL      | ALB     | Albania            | Tirana     | Europe    | +355        | ALL            | sq         | 🇦🇱  | [Link](https://en.wikipedia.org/wiki/ISO_3166-2:AL) |
| DZ      | DZA     | Algeria            | Algiers    | Africa    | +213        | DZD            | ar         | 🇩🇿  | [Link](https://en.wikipedia.org/wiki/ISO_3166-2:DZ) |
| ...     | ...     | ...                | ...        | ...       | ...         | ...            | ...        | ...  | ...       |

# List of Languages
| Alpha-2 | Alpha-3 | Name          | Native Name | Family              |
|---------|---------|---------------|-------------|---------------------|
| aa      | aar     | Afar          | Afar        | Afro-Asiatic        |
| ab      | abk     | Abkhaz        | Аҧсуа       | Northwest Caucasian |
| ae      | ave     | Avestan       | avesta      | Indo-European       |
| af      | afr     | Afrikaans     | Afrikaans   | Indo-European       |
| ...     | ...     | ...           | ...         | ...                 |

# List of Currencies
| Alpha-3 | Name                            | Number | Minor Unit |
|---------|---------------------------------|--------|------------|
| AED     | United Arab Emirates dirham    | 784    | 2          |
| AFN     | Afghan afghani                 | 971    | 2          |
| ALL     | Albanian lek                    | 8      | 2          |
| AMD     | Armenian dram                   | 51     | 2          |
| ...     | ...                             | ...    | ...        |

