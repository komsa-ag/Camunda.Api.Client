using Newtonsoft.Json.Serialization;

namespace Camunda.Api.Client;

internal class StringEnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
{
  private static readonly CamelCaseNamingStrategy _camelCaseNamingStrategy = new();

  public StringEnumConverter()
  {
    NamingStrategy = _camelCaseNamingStrategy;
    AllowIntegerValues = false; // integer values are not allowed because they dont't have API origin
  }
}
