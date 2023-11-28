namespace IO.DXHeroes.PlainSDK;

public class Name : ApiModule
{
  public Name(HttpClient httpClient) : base(httpClient)
  {
  }

  public async Task<NameValidationResponse> Validate(NameValidationRequestBody requestBody, string apiVersion = "2.0", bool IncludeFoxentryRequestDetails = false) 
  {
    return await Request<NameValidationRequestBody, NameValidationResponse>(
      $"/api/{apiVersion}/name/validate",
      requestBody,
      new Dictionary<string, string> { { "Foxentry-Include-Request-Details", IncludeFoxentryRequestDetails.ToString() }, { "Api-Version", apiVersion } }
    );
  }
}
