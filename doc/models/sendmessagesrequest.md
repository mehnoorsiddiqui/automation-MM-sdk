
# Sendmessagesrequest

## Structure

`Sendmessagesrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Messages` | [`List<Models.Message>`](/doc/models/message.md) | Required | - |

## Example (as JSON)

```json
{
  "messages": [
    {
      "content": "My first message",
      "destination_number": "+61491570156",
      "source_number": "+61491570157"
    }
  ]
}
```

