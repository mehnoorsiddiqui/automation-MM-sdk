
# Message Template

## Structure

`MessageTemplate`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Content` | `string` | Required | The message content.  This supports template placeholders. |
| `Metadata` | `object` | Optional | Message metadata.  This will be supplied to URL shortener and UG.  Max 10 keys per campaign. |
| `RichLink` | [`Models.RichLink`](/doc/models/rich-link.md) | Optional | - |
| `DeliveryReport` | `bool?` | Optional | Request a delivery report for the sent message |

## Example (as JSON)

```json
{
  "content": "content4",
  "metadata": null,
  "rich_link": null,
  "delivery_report": null
}
```

