
# Retrieve Webhook Response

## Structure

`RetrieveWebhookResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Page` | `int` | Required | - |
| `PageSize` | `int` | Required | - |
| `PageData` | [`List<Models.PageDatum>`](/doc/models/page-datum.md) | Required | - |

## Example (as JSON)

```json
{
  "page": 0,
  "pageSize": 100,
  "pageData": [
    {
      "url": "https://webhook.com",
      "method": "POST",
      "id": "8805c9d8-bef7-41c7-906a-69ede93aa024",
      "encoding": "JSON",
      "events": [
        "RECEIVED_SMS"
      ],
      "headers": {},
      "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
    }
  ]
}
```

