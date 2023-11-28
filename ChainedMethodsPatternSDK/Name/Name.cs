namespace IO.DXHeroes.ChainedMethodsPatternSDK;

public class Name
{
  private readonly HttpClient _httpClient;

  public Name(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public NameValidation Validate() => new(_httpClient);
}
