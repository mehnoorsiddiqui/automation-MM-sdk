
# Log Summary Result

## Structure

`LogSummaryResult`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TotalClicks` | `double?` | Optional | - |
| `UniqueClicks` | `double?` | Optional | - |
| `TotalViews` | `double?` | Optional | - |
| `UniqueViews` | `double?` | Optional | - |
| `ShortUrlsGenerated` | `double?` | Optional | - |
| `ShortUrls` | [`List<Models.ShortUrl>`](/doc/models/short-url.md) | Optional | - |
| `Pagination` | [`Models.Pagination1`](/doc/models/pagination-1.md) | Optional | - |

## Example (as JSON)

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

