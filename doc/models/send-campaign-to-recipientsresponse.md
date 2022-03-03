
# Send Campaign to Recipientsresponse

## Structure

`SendCampaignToRecipientsresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Recipients` | [`List<Models.Recipient1>`](../../doc/models/recipient-1.md) | Required | - |

## Example (as JSON)

```json
{
  "recipients": [
    {
      "id": "05f81030-95fb-4c17-8736-ac73948e8b82",
      "number": "61491570156",
      "parameters": {
        "firstName": "John",
        "lastName": "English"
      }
    },
    {
      "id": "01261663-9428-4a1d-9798-e8a1877cc29d",
      "number": "61491570158",
      "parameters": {
        "firstName": "Mary",
        "lastName": "Example"
      }
    }
  ]
}
```

