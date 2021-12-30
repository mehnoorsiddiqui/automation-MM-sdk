
# Properties 33

## Structure

`Properties33`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EndDate` | `string` | Required | End date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format. |
| `StartDate` | `string` | Required | Start date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format. |
| `Filters` | `object` | Optional | Any filters provided as parameters for this report |
| `Grouping` | [`Models.GroupingEnum?`](/doc/models/grouping-enum.md) | Optional | The value of the group by parameter provided for this report |
| `Summary` | [`Models.SummaryEnum?`](/doc/models/summary-enum.md) | Optional | The value of the summary_by parameter provided for this report |
| `SummaryField` | [`Models.SummaryFieldEnum?`](/doc/models/summary-field-enum.md) | Optional | The value of the summary_field parameter provided for this report |
| `Timezone` | `string` | Optional | - |

## Example (as JSON)

```json
{
  "end_date": "02/10/2017 13:30:00",
  "start_date": "02/12/2017 13:30:00"
}
```

