
# Message

## Structure

`Message`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CallbackUrl` | `string` | Optional | URL replies and delivery reports to this message will be pushed to |
| `Content` | `string` | Required | Content of the message<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `5000` |
| `DestinationNumber` | `string` | Required | Destination number of the message<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `DeliveryReport` | `bool?` | Optional | Request a delivery report for this message |
| `Format` | [`Models.FormatEnum?`](/doc/models/format-enum.md) | Optional | Format of message, SMS or TTS (Text To Speech). |
| `MessageExpiryTimestamp` | `DateTime?` | Optional | Date time after which the message expires and will not be sent |
| `Metadata` | `object` | Optional | Metadata for the message specified as a set of key value pairs, each key can be up to 100 characters long and each value can be up to 256 characters long<br><br>```<br>{<br>   "myKey": "myValue",<br>   "anotherKey": "anotherValue"<br>}<br>``` |
| `Scheduled` | `DateTime?` | Optional | Scheduled delivery date time of the message |
| `SourceNumber` | `string` | Required | Source number of the message |
| `SourceNumberType` | [`Models.SourceNumberTypeEnum?`](/doc/models/source-number-type-enum.md) | Optional | Type of source address specified, this can be INTERNATIONAL, ALPHANUMERIC or SHORTCODE |
| `MessageId` | `Guid?` | Optional | Unique ID of this message |
| `Status` | [`Models.StatusEnum?`](/doc/models/status-enum.md) | Optional | The status of the message |
| `Media` | `List<string>` | Optional | The media is used to specify a list of URLs of the media file(s) that you are trying to send. Supported file formats include png, jpeg and gif. format parameter must be set to MMS for this to work. |
| `Subject` | `string` | Optional | The subject field is used to denote subject of the MMS message and has a maximum size of 64 characters long |

## Example (as JSON)

```json
{
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
```

