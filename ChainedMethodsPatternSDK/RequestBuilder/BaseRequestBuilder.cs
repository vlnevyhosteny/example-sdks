using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace IO.DXHeroes.ChainedMethodsPatternSDK;

public abstract class BaseRequestBuilder<B, R> : IRequestBuilder<B, R> where B : class where R : class
{
  private B? _body;

  public HttpClient HttpClient { get; }
  public string Path { get; }

  public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

  public BaseRequestBuilder(HttpClient httpClient, string path)
  {
    HttpClient = httpClient;
    Path = path;
  }

  protected IRequestBuilder<B, R> WithBody(B body)
  {
    _body = body;
    return this;
  }

  public async Task<R> Execute() 
  {
    using StringContent jsonContent = new(
        JsonSerializer.Serialize(
            _body,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        ),
        Encoding.UTF8,
        "application/json");

    using HttpRequestMessage request = new(HttpMethod.Post, Path)
    {
      Content = jsonContent
    };
    Headers.ToList().ForEach(header => request.Headers.Add(header.Key, header.Value));

    using HttpResponseMessage response = await HttpClient.SendAsync(request);

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadFromJsonAsync<R>() ?? throw new Exception("Response was null");
  }
}
