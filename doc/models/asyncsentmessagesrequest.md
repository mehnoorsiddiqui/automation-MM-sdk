
# Asyncsentmessagesrequest

## Structure

`Asyncsentmessagesrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EndDate` | `string` | Optional | End date time for report window. |
| `StartDate` | `string` | Optional | Start date time for report window. |
| `SummaryBy` | [`Models.SummaryByEnum?`](/doc/models/summary-by-enum.md) | Optional | Function to apply when summarising results |
| `SummaryField` | [`Models.SummaryFieldEnum?`](/doc/models/summary-field-enum.md) | Optional | The value of the summary_field parameter provided for this report |
| `GroupBy` | [`List<Models.GroupByEnum>`](/doc/models/group-by-enum.md) | Optional | List of fields to group results set by |
| `Period` | [`Models.PeriodEnum?`](/doc/models/period-enum.md) | Optional | Automatically set a date range based on the period value. Can't be combined with start_date and end_date. |
| `Timezone` | `string` | Optional | The timezone to use for the context of the request. |
| `Accounts` | `List<string>` | Optional | Filter results by a specific account. |
| `DestinationAddressCountry` | `string` | Optional | Filter results by destination address country. |
| `DestinationAddress` | `string` | Optional | Filter results by destination address. |
| `MessageFormat` | [`Models.Format1Enum?`](/doc/models/format-1-enum.md) | Optional | Format of message, SMS or TTS (Text To Speech) |
| `MetadataKey` | `string` | Optional | Filter results for messages that include a metadata key. |
| `MetadataValue` | `string` | Optional | Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided. |
| `SourceAddressCountry` | `string` | Optional | Filter results by source address country. |
| `SourceAddress` | `string` | Optional | Filter results by source address. |
| `DeliveryReport` | `bool?` | Optional | Filter results by delivery report. |
| `StatusCode` | `string` | Optional | Filter results by message status code. |
| `DeliveryOptions` | [`List<Models.DeliveryOptionsBody>`](/doc/models/delivery-options-body.md) | Optional | Delivery options for this asynchronous report. |

## Example (as JSON)

```json
{
  "end_date": "2017-02-10T13:30:00.000Z",
  "start_date": "2017-02-12T13:30:00.000Z",
  "group_by": [
    "DAY"
  ],
  "period": "YESTERDAY",
  "timezone": "Australia/Melbourne",
  "accounts": [],
  "delivery_options": [
    {
      "delivery_type": "EMAIL",
      "delivery_addresses": [],
      "delivery_format": "CSV"
    }
  ]
}
```

