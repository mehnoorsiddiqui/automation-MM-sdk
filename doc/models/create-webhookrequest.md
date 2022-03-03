
# Create Webhookrequest

## Structure

`CreateWebhookrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Url` | `string` | Required | The configured URL which will trigger the webhook when a selected event occurs. |
| `Method` | `string` | Required | The methods to map CRUD (create, retrieve, update, delete) operations to HTTP requests. |
| `Encoding` | `string` | Required | Webhooks can be delivered using different content types. You can choose from `JSON`, `FORM_ENCODED` or `XML`. This will automatically add the Content-Type header for you so you don't have to add it again in the `headers` property. |
| `Headers` | [`Models.Headers`](../../doc/models/headers.md) | Required | - |
| `Events` | `List<string>` | Required | Event or events that will trigger the webhook. Atleast one event should be present. |
| `Template` | `string` | Required | The structure of the payload that will be returned. You can format this in JSON or XML. |

## Example (as JSON)

```json
{
  "url": "http://webhook.com",
  "method": "POST",
  "encoding": "JSON",
  "headers": {
    "Account": "DeveloperPortal7000"
  },
  "events": [
    "ENROUTE_DR",
    "DELIVERED_DR"
  ],
  "template": "{\"id\":\"$mtId\",\"status\":\"$statusCode\"}"
}
```

