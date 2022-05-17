# Short Trackable Links Reports

Short Trackable Links is a feature available to [Messaging API](https://developers.messagemedia.com/code/messages-api-documentation/) users whereby it automatically and seamlessly shortens any URL to just 22 characters. Every shortened URL is unique to each recipient.

The reporting API has endpoints specific to
this feature, allowing users to obtain details regarding
the number of click-throughs on each URL.

To enable this feature on your account, contact your account manager or contact support on [support@messagemedia.com](support@messagemedia.com).

To learn more about the benefits of the Short Trackable Links feature, [visit MessageMedia feature page](https://messagemedia.com/au/feature/short-urls/).

```csharp
ShortTrackableLinksReportsController shortTrackableLinksReportsController = client.ShortTrackableLinksReportsController;
```

## Class Name

`ShortTrackableLinksReportsController`

## Methods

* [Log Summary](../../doc/controllers/short-trackable-links-reports.md#log-summary)
* [Log Detail](../../doc/controllers/short-trackable-links-reports.md#log-detail)


# Log Summary

Clicks summary report for metadata key value pair, long url and short url.

```csharp
LogSummaryAsync(
    string key = null,
    string mValue = null,
    string url = null,
    string recipient = null,
    double? page = null,
    double? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Query, Optional | - |
| `mValue` | `string` | Query, Optional | - |
| `url` | `string` | Query, Optional | - |
| `recipient` | `string` | Query, Optional | - |
| `page` | `double?` | Query, Optional | - |
| `pageSize` | `double?` | Query, Optional | - |

## Response Type

[`Task<Models.LogSummaryResult>`](../../doc/models/log-summary-result.md)

## Example Usage

```csharp
try
{
    LogSummaryResult result = await shortTrackableLinksReportsController.LogSummaryAsync(null, null, null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "total_clicks": 3,
  "unique_clicks": 1,
  "total_views": 2,
  "unique_views": 1,
  "short_urls_generated": 1,
  "short_urls": [
    {
      "click_count": 3,
      "view_count": 2,
      "message_id": "00000000-0000-0000-0000-000000000000",
      "long_url": "https://developers.messagemedia.com",
      "short_url": "https://nxt.to/abc1234",
      "destination_number": "61491570157"
    }
  ],
  "pagination": {
    "page": 1,
    "page_size": 100,
    "page_count": 3
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Invalid data provided | `ApiException` |
| 404 | Data cannot be found | `ApiException` |
| 500 | System Error | `ApiException` |


# Log Detail

Detailed clicks report for a hashcode.

```csharp
LogDetailAsync(
    string hash,
    double? page = null,
    double? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `hash` | `string` | Query, Required | - |
| `page` | `double?` | Query, Optional | - |
| `pageSize` | `double?` | Query, Optional | - |

## Response Type

[`Task<Models.LogsDetailResult>`](../../doc/models/logs-detail-result.md)

## Example Usage

```csharp
string hash = "hash6";

try
{
    LogsDetailResult result = await shortTrackableLinksReportsController.LogDetailAsync(hash, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "message_id": "00000000-0000-0000-0000-000000000000",
  "long_url": "https://developers.messagemedia.com",
  "short_url": "https://nxt.to/abc1234",
  "destination_number": "61491570157",
  "click_count": 3,
  "view_count": 2,
  "clicks": [
    {
      "dt": "2018-09-18T01:22:17.071Z",
      "user_agent": "Mozilla/5.0 (Windows NT...",
      "ip": "127.0.0.1"
    }
  ],
  "views": [
    {
      "dt": "2018-09-18T01:22:17.071Z",
      "user_agent": "Mozilla/5.0 (Windows NT...",
      "ip": "127.0.0.1"
    }
  ],
  "pagination": {
    "page": 1,
    "page_size": 100,
    "page_count": 3
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Invalid data provided | `ApiException` |
| 404 | Data cannot be found | `ApiException` |
| 500 | System Error | `ApiException` |

