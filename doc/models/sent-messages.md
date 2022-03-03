
# Sent Messages

## Structure

`SentMessages`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Data` | [`List<Models.SentMessage>`](../../doc/models/sent-message.md) | Optional | List of sent messages |
| `Pagination` | [`Models.Pagination1`](../../doc/models/pagination-1.md) | Optional | - |
| `Properties` | [`Models.ReportingDetailProperties`](../../doc/models/reporting-detail-properties.md) | Optional | - |

## Example (as JSON)

```json
{
  "data": [
    {
      "account": "MyAccount001",
      "content": "Hello world!",
      "delivered_timestamp": "2017-02-12T13:30:00.000Z",
      "destination_address": "61491570156",
      "destination_address_country": "AU",
      "format": "SMS",
      "source_address": "61491570156",
      "source_address_country": "AU",
      "units": 2,
      "timestamp": "2017-02-12T13:30:00.000Z"
    }
  ],
  "pagination": {},
  "properties": {
    "end_date": "2017-02-10T13:30:00.000Z",
    "start_date": "2017-02-12T13:30:00.000Z",
    "sorting": {},
    "filters": {
      "accounts": []
    },
    "timezone": "The timezone that this report is presented in, this may be passed in as a parameter to the report, or taken from account settings"
  }
}
```

