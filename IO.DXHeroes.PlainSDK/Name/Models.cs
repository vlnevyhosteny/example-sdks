namespace IO.DXHeroes.PlainSDK;

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
