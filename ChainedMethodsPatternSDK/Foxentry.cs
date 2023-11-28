using System.Net.Http.Headers;

namespace IO.DXHeroes.ChainedMethodsPatternSDK;

public class Foxentry
{
  private readonly string BASE_URL = "https://api.foxentry.com/";
  private readonly HttpClient _httpClient;

  public Name Name { get => new(_httpClient); } 

  public Foxentry()
  {
    _httpClient = new HttpClient { BaseAddress = new Uri(BASE_URL) };
  }

  public Foxentry SetBearerToken(string token)
  {
    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    return this;
  }
}
