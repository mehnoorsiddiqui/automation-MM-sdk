
# List Campaign Event Page

## Structure

`ListCampaignEventPage`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Events` | [`List<Models.CampaignEvent>`](/doc/models/campaign-event.md) | Required | The list of campaign events. |
| `Pagination` | [`Models.Pagination1`](/doc/models/pagination-1.md) | Required | - |

## Example (as JSON)

```json
{
  "events": [
    {
      "campaign_id": "campaign_id0",
      "recipient_id": "recipient_id0",
      "number": "number2",
      "event": "event0",
      "source": null,
      "timestamp": "timestamp8"
    }
  ],
  "pagination": {
    "page": null,
    "page_size": null,
    "total_count": null,
    "page_count": null,
    "next_uri": null,
    "previous_uri": null
  }
}
```

