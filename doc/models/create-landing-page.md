
# Create Landing Page

## Structure

`CreateLandingPage`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Required | Landing Page name. Maximum 100 characters. |
| `TemplateId` | `string` | Required | Template to use for the landing page. |
| `Parameters` | `object` | Optional | Parameters to use for the landing page and the message content. |
| `Fields` | `object` | Optional | Define the fields that have been used to the paramters. |

## Example (as JSON)

```json
{
  "name": "name0",
  "template_id": "template_id0",
  "parameters": null,
  "fields": null
}
```

