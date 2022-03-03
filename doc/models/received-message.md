
# Received Message

A message received for the account specified. This message may be in response to a sent message, or it may be an unsolicited message, matched to the account by the destination address.

## Structure

`ReceivedMessage`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Account` | `string` | Optional | Account associated with this message |
| `Action` | [`Models.ActionEnum?`](../../doc/models/action-enum.md) | Optional | Action that was invoked for this message if any, OPT_OUT, OPT_IN, GLOBAL_OPT_OUT |
| `Content` | `string` | Optional | Content of the message |
| `DestinationAddress` | `string` | Optional | Address this message was delivered to. If this message was received in response to a sent message, this is the source address of the sent message |
| `DestinationAddressCountry` | `string` | Optional | Country associated with the destination address |
| `Format` | [`Models.Format1Enum?`](../../doc/models/format-1-enum.md) | Optional | Format of message, SMS or TTS (Text To Speech) |
| `Id` | `string` | Optional | Unique ID for this reply |
| `InResponseTo` | `string` | Optional | If this message was received in response to a sent message, this is the ID of the sent message |
| `Metadata` | `object` | Optional | If this message was received in response to a sent message, this is the metadata associated with the sent message |
| `SourceAddress` | `string` | Optional | Address this message was received from. If this message was received in response to a sent message, this is the destination address of the sent message. |
| `SourceAddressCountry` | `string` | Optional | Country associated with the source address |
| `Timestamp` | `string` | Optional | Date time at which this message was received |

## Example (as JSON)

```json
{
  "account": null,
  "action": null,
  "content": null,
  "destination_address": null,
  "destination_address_country": null,
  "format": null,
  "id": null,
  "in_response_to": null,
  "metadata": null,
  "source_address": null,
  "source_address_country": null,
  "timestamp": null
}
```

