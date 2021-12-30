
# Asyncsentmessagesdetailrequest

## Structure

`Asyncsentmessagesdetailrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EndDate` | `string` | Optional | End date time for report window. |
| `StartDate` | `string` | Optional | Start date time for report window. |
| `Period` | [`Models.PeriodEnum?`](/doc/models/period-enum.md) | Optional | Automatically set a date range based on the period value. Can't be combined with start_date and end_date. |
| `SortBy` | [`Models.SortByEnum?`](/doc/models/sort-by-enum.md) | Optional | Field to sort results set by |
| `SortDirection` | [`Models.SortDirectionEnum?`](/doc/models/sort-direction-enum.md) | Optional | Order to sort results by. |
| `Timezone` | `string` | Optional | The timezone to use for the context of the request. |
| `Accounts` | `List<string>` | Optional | Filter results by a specific account. |
| `DestinationAddressCountry` | `string` | Optional | Filter results by destination address country. |
| `DestinationAddress` | `string` | Optional | Filter results by destination address. |
| `MessageFormat` | [`Models.Format1Enum?`](/doc/models/format-1-enum.md) | Optional | Format of message, SMS or TTS (Text To Speech) |
| `MetadataKey` | `string` | Optional | Filter results for messages that include a metadata key. |
| `MetadataValue` | `string` | Optional | Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided. |
| `SourceAddressCountry` | `string` | Optional | Filter results by source address country. |
| `SourceAddress` | `string` | Optional | Filter results by source address. |
| `Status` | [`Models.Status1Enum?`](/doc/models/status-1-enum.md) | Optional | Filter results by message status. Can't be combined with statuses. |
| `Statuses` | [`List<Models.StatusesEnum>`](/doc/models/statuses-enum.md) | Optional | Filter results by message statuses. Can't be combined with status. |
| `StatusCode` | `string` | Optional | Filter results by message status code. |
| `DeliveryReport` | `bool?` | Optional | Filter results by delivery report. |
| `DeliveryOptions` | [`List<Models.DeliveryOptionsBody>`](/doc/models/delivery-options-body.md) | Optional | Delivery options for this asynchronous report. |

## Example (as JSON)

```json
{
  "end_date": "2017-02-10T13:30:00.000",
  "start_date": "2017-02-12T13:30:00.000",
  "period": "TODAY",
  "sort_by": "ACCOUNT",
  "sort_direction": "ASCENDING",
  "timezone": "Australia/Melbourne",
  "accounts": [],
  "statuses": [
    "CANCELLED"
  ],
  "delivery_options": [
    {
      "delivery_type": "EMAIL",
      "delivery_addresses": [],
      "delivery_format": "CSV"
    }
  ]
}
```

