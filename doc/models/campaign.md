
# Campaign

## Structure

`Campaign`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TemplateId` | `string` | Required | Template to use for the landing page |
| `Parameters` | `object` | Optional | Parameters to use for the landing page and the message content |
| `Message` | [`Models.MessageTemplate`](../../doc/models/message-template.md) | Required | - |

## Example (as JSON)

```json
{
  "template_id": "template_id0",
  "parameters": null,
  "message": {
    "content": "content4",
    "metadata": null,
    "rich_link": null,
    "delivery_report": null
  }
}
```

