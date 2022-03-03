
# Createa Landing Pageresponse

## Structure

`CreateaLandingPageresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | - |
| `Name` | `string` | Required | - |
| `TemplateId` | `string` | Required | - |
| `Parameters` | [`Models.Parameters`](../../doc/models/parameters.md) | Required | - |
| `Fields` | [`Models.Fields`](../../doc/models/fields.md) | Required | - |
| `CreatedTimestamp` | `string` | Required | - |
| `ModifiedTimestamp` | `string` | Required | - |

## Example (as JSON)

```json
{
  "id": "a94041bb-704b-48fa-ba0b-6f1538fc502f",
  "name": " My Landing Page",
  "template_id": "ac895f01-3149-4bf8-a8fe-01d3b8a9ba97",
  "parameters": {
    "title": "This is a ${title}",
    "bodyText": "This is some ${bodyText}",
    "callToAction": "${ctaUrl}"
  },
  "fields": {
    "title": {
      "type": "TEXT"
    },
    "bodyText": {
      "type": "TEXT"
    },
    "ctaUrl": {
      "type": "URL"
    }
  },
  "created_timestamp": "2019-11-03T11:49:02.807Z",
  "modified_timestamp": "2019-11-03T11:49:02.807Z"
}
```

