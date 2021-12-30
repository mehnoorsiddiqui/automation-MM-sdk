
# Badrequest Exception

## Structure

`BadrequestException`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Message` | `string` | Required | - |
| `Details` | `List<string>` | Required | - |

## Example (as JSON)

```json
{
  "message": "Request failed to parse correctly. Please ensure input is valid and try again.",
  "details": [
    "Failed to parse message body."
  ]
}
```

