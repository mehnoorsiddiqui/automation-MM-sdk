
# Reporting Detail Properties

## Structure

`ReportingDetailProperties`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EndDate` | `string` | Required | End date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format. |
| `StartDate` | `string` | Required | Start date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format. |
| `Sorting` | [`Models.Sorting`](/doc/models/sorting.md) | Optional | - |
| `Filters` | [`Models.Filters`](/doc/models/filters.md) | Optional | - |
| `Timezone` | `string` | Optional | - |

## Example (as JSON)

```json
{
  "end_date": "02/10/2017 13:30:00",
  "start_date": "02/12/2017 13:30:00"
}
```

