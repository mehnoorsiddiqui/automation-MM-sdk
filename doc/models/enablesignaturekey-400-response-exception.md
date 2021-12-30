
# Enablesignaturekey 400 Response Exception

## Structure

`Enablesignaturekey400responseException`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Message` | `string` | Required | - |
| `Details` | `List<string>` | Required | - |

## Example (as JSON)

```json
{
  "message": "Bad Request",
  "details": [
    "/key_id: Key id cannot be null"
  ]
}
```

