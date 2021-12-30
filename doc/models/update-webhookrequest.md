
# Update Webhookrequest

## Structure

`UpdateWebhookrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Url` | `string` | Required | - |
| `Method` | `string` | Required | - |
| `Encoding` | `string` | Required | - |
| `Events` | `List<string>` | Required | - |
| `Template` | `string` | Required | - |

## Example (as JSON)

```json
{
  "url": "https://myurl.com",
  "method": "POST",
  "encoding": "FORM_ENCODED",
  "events": [
    "ENROUTE_DR"
  ],
  "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
}
```

