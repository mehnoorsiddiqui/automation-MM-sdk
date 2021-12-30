
# Campaign Summary

## Structure

`CampaignSummary`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TotalEvents` | `double` | Required | The total number of events record against this campaign. |
| `UniqueEngagements` | `double` | Required | The unique number of recipients for which there exists at least one recorded event. |
| `EventSummary` | [`List<Models.EventSummary>`](/doc/models/event-summary.md) | Required | The event summary breakdown. |

## Example (as JSON)

```json
{
  "total_events": 85.9,
  "unique_engagements": 29.36,
  "event_summary": [
    {
      "event": "event3",
      "source": null,
      "total_events": 126.53,
      "unique_recipients": 245.63
    },
    {
      "event": "event4",
      "source": null,
      "total_events": 126.54,
      "unique_recipients": 245.64
    },
    {
      "event": "event5",
      "source": null,
      "total_events": 126.55,
      "unique_recipients": 245.65
    }
  ]
}
```

