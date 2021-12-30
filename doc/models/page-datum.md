
# Page Datum

## Structure

`PageDatum`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Url` | `string` | Required | - |
| `Method` | `string` | Required | - |
| `Id` | `string` | Required | - |
| `Encoding` | `string` | Required | - |
| `Events` | `List<string>` | Required | - |
| `Headers` | `object` | Required | - |
| `Template` | `string` | Required | - |

## Example (as JSON)

```json
{
  "url": "https://webhook.com",
  "method": "POST",
  "id": "8805c9d8-bef7-41c7-906a-69ede93aa024",
  "encoding": "JSON",
  "events": [
    "RECEIVED_SMS"
  ],
  "headers": {},
  "template": "{\r\n  \"id\": \"$mtId\",\r\n  \"status\": \"$statusCode\"\r\n}"
}
```

