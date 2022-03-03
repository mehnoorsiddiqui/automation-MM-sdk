
# Create New Campaignresponse

## Structure

`CreateNewCampaignresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | - |
| `TemplateId` | `string` | Required | - |
| `Parameters` | [`Models.Parameters`](../../doc/models/parameters.md) | Required | - |
| `Message` | [`Models.Message`](../../doc/models/message.md) | Required | - |

## Example (as JSON)

```json
{
  "id": null,
  "template_id": null,
  "parameters": {
    "title": "This is a title",
    "bodyText": "This is some body text",
    "callToAction": "http://www.example.com/"
  },
  "message": {
    "callback_url": "https://my.url.com",
    "content": "Hello world!",
    "destination_number": "+61491570156",
    "delivery_report": false,
    "format": "SMS",
    "message_expiry_timestamp": "2016-11-03T11:49:02.000+00:00",
    "metadata": {},
    "scheduled": "2016-11-03T11:49:02.000+00:00",
    "source_number": "+61491570156",
    "source_number_type": "INTERNATIONAL",
    "message_id": "d7d9d9fd-478f-40e6-b651-49b7f19878a2",
    "status": "enroute",
    "media": [
      "https://images.pexels.com/photos/1018350/pexels-photo-1018350.jpeg?cs=srgb&dl=architecture-buildings-city-1018350.jpg"
    ],
    "subject": "string"
  }
}
```

