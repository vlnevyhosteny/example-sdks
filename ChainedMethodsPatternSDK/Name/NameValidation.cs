
namespace IO.DXHeroes.ChainedMethodsPatternSDK;

public sealed class NameValidationResponse 
{
  public required int Status { get; set; }
  public required string Result { get; set; }
  public string? ResultCorrected { get; set; }
}

public sealed class NameValidationRequestBody 
{
  public string? CustomId { get; set; }
  public required string Query { get; set; }
}

public class NameValidation : BaseRequestBuilder<NameValidationRequestBody, NameValidation>
{
  private const string PATH = "/name/validate";

  public NameValidation(HttpClient httpClient) : base(httpClient, PATH)
  {
  }

  public NameValidation WithApiVersion(string version) 
  {
    Headers.Add("Api-Version", version);
    return this;
  }

  public NameValidation IncludeRequestDetails() 
  {
    Headers.Add("Foxentry-Include-Request-Details", "true");
    return this;
  }

  public NameValidation WithQuery(NameValidationRequestBody body) 
  {
    WithBody(body);
    return this;
  }
}
