# ISO.csharp

A C# library providing ISO 3166-1,2 and ISO 639-1-2 data.



https://www.nuget.org/packages/ISOLib/

[![ISOLib](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/AlexanderIbraimov/ISO.csharp/actions/workflows/dotnet.yml)
## Usage

### ISO 3166

   ```csharp
      ISO<Country> iso3166 = new ISO3166();
      Country[] countries = iso3166.GetArray();
   ```
 
### ISO 639

   ```csharp
      ISO<Language> iso639 = new ISO639();
      Language[] languages = iso639.GetArray();
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

