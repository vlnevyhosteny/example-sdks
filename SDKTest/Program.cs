using ChainedMethodsPatternSDK = IO.DXHeroes.ChainedMethodsPatternSDK;
using ClassicSDK = IO.DXHeroes.PlainSDK;

var fluent = new ChainedMethodsPatternSDK.Foxentry();
await fluent.SetBearerToken("token")
            .Name
            .Validate()
            .WithQuery(new ChainedMethodsPatternSDK.NameValidationRequestBody { Query = "John Doe" })
            .WithApiVersion("2.0")
            .IncludeRequestDetails()
            .Execute();

var classic = new ClassicSDK.Foxentry("token");
await classic.Name.Validate(new ClassicSDK.NameValidationRequestBody { Query = "John Doe" }, "2.0", true);