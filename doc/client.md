
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `BasicAuthUserName` | `string` | The username to use with basic authentication |
| `BasicAuthPassword` | `string` | The password to use with basic authentication |

The API client can be initialized as follows:

```csharp
MessageMedia.Standard.MessageMediaClient client = new MessageMedia.Standard.MessageMediaClient.Builder().Build();
```

## MessageMediaClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| MessagesController | Gets MessagesController controller. |
| DeliveryReportsController | Gets DeliveryReportsController controller. |
| RepliesController | Gets RepliesController controller. |
| LookupsController | Gets LookupsController controller. |
| NumberAuthorisationController | Gets NumberAuthorisationController controller. |
| DedicatedNumbersController | Gets DedicatedNumbersController controller. |
| MessagingReportsController | Gets MessagingReportsController controller. |
| ShortTrackableLinksReportsController | Gets ShortTrackableLinksReportsController controller. |
| WebhooksManagementController | Gets WebhooksManagementController controller. |
| SignatureKeyManagementController | Gets SignatureKeyManagementController controller. |
| MobileLandingPagesBetaController | Gets MobileLandingPagesBetaController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the MessageMediaClient using the values provided for the builder. | `Builder` |

## MessageMediaClient Builder Class

Class to build instances of MessageMediaClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |

