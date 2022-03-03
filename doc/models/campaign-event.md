
# Campaign Event

## Structure

`CampaignEvent`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CampaignId` | `string` | Required | The campaign ID |
| `RecipientId` | `string` | Required | The recipient ID to which this event corresponds to |
| `Number` | `string` | Required | The recipient's phone number |
| `Event` | `string` | Required | The event type.  See [Event Types](../../#events-types) for a list of available events. |
| `Source` | `string` | Optional | The source identifier.  This identifies the element that produced the event.  This may not be applicable for all events. |
| `Timestamp` | `string` | Required | The timestamp of the event, in ISO 8601 format. |

## Example (as JSON)

```json
{
  "campaign_id": "campaign_id0",
  "recipient_id": "recipient_id0",
  "number": "number2",
  "event": "event0",
  "source": null,
  "timestamp": "timestamp2"
}
```

