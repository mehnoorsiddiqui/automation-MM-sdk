
# Getmessagestatusresponse

## Structure

`Getmessagestatusresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CallbackUrl` | `string` | Optional | URL replies and delivery reports to this message will be pushed to |
| `Content` | `string` | Optional | Content of the message<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `5000` |
| `DestinationNumber` | `string` | Optional | Destination number of the message<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `DeliveryReport` | `bool?` | Optional | Request a delivery report for this message |
| `Format` | [`Models.FormatEnum?`](../../doc/models/format-enum.md) | Optional | Format of message, SMS or TTS (Text To Speech). |
| `MessageExpiryTimestamp` | `DateTime?` | Optional | Date time after which the message expires and will not be sent |
| `Metadata` | `object` | Optional | Metadata for the message specified as a set of key value pairs, each key can be up to 100 characters long and each value can be up to 256 characters long<br><br>```<br>{<br>   "myKey": "myValue",<br>   "anotherKey": "anotherValue"<br>}<br>``` |
| `Scheduled` | `DateTime?` | Optional | Scheduled delivery date time of the message |
| `SourceNumber` | `string` | Optional | - |
| `SourceNumberType` | [`Models.SourceNumberTypeEnum?`](../../doc/models/source-number-type-enum.md) | Optional | Type of source address specified, this can be INTERNATIONAL, ALPHANUMERIC or SHORTCODE |
| `MessageId` | `Guid?` | Optional | Unique ID of this message |
| `Status` | [`Models.StatusEnum?`](../../doc/models/status-enum.md) | Optional | The status of the message |

## Example (as JSON)

```json
{
  "format": "SMS",
  "content": "My first message!",
  "metadata": {
    "key1": "value1",
    "key2": "value2"
  },
  "message_id": "877c19ef-fa2e-4cec-827a-e1df9b5509f7",
  "callback_url": "https://my.callback.url.com",
  "delivery_report": true,
  "destination_number": "+61401760575",
  "scheduled": "2016-11-03T11:49:02.807Z",
  "source_number": "+61491570157",
  "source_number_type": "INTERNATIONAL",
  "message_expiry_timestamp": "2016-11-03T11:49:02.807Z",
  "status": "enroute"
}
```

