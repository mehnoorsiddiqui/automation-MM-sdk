
# Logs Detail Result

## Structure

`LogsDetailResult`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MessageId` | `string` | Optional | - |
| `LongUrl` | `string` | Optional | - |
| `ShortUrl` | `string` | Optional | - |
| `DestinationNumber` | `string` | Optional | - |
| `ClickCount` | `double?` | Optional | - |
| `ViewCount` | `double?` | Optional | - |
| `Clicks` | [`List<Models.Click>`](../../doc/models/click.md) | Optional | - |
| `Views` | [`List<Models.View>`](../../doc/models/view.md) | Optional | - |
| `Pagination` | [`Models.Pagination1`](../../doc/models/pagination-1.md) | Optional | - |

## Example (as JSON)

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

