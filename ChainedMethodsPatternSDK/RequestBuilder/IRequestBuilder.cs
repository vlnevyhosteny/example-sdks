namespace IO.DXHeroes.ChainedMethodsPatternSDK;

public interface IRequestBuilder<B, R> where B : class where R : class
{
  HttpClient HttpClient { get; }
  string Path { get; }
  Task<R> Execute();
}
