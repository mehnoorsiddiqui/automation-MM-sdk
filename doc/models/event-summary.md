
# Event Summary

## Structure

`EventSummary`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Event` | `string` | Required | The event type to which this summary is for.  See [Event Types](#events-types) for a list of available events. |
| `Source` | `string` | Optional | The event source to which this summary is for, if applicable. |
| `TotalEvents` | `double` | Required | The total number of recorded events of this type and source. |
| `UniqueRecipients` | `double` | Required | The unique number of recipients for which there exists at least one event of this type and source recorded. |

## Example (as JSON)

```json
{
  "event": "event0",
  "source": null,
  "total_events": 85.9,
  "unique_recipients": 205.0
}
```

