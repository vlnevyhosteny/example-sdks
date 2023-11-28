using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace IO.DXHeroes.PlainSDK;

public abstract class ApiModule
{
  public HttpClient HttpClient { get; }

  public ApiModule(HttpClient httpClient)
  {
    HttpClient = httpClient;
  }

  protected async Task<R> Request<B, R>(string path, B body, IDictionary<string, string> headers = null) where B : class where R : class
  {
    using StringContent jsonContent = new(
      JsonSerializer.Serialize(
          body,
          new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
      ),
      Encoding.UTF8,
      "application/json");

    using HttpRequestMessage request = new(HttpMethod.Post, path)
    {
      Content = jsonContent
    };
    headers?.ToList().ForEach(header => request.Headers.Add(header.Key, header.Value));

    using HttpResponseMessage response = await HttpClient.SendAsync(request);

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadFromJsonAsync<R>() ?? throw new Exception("Response was null");
  }
}
