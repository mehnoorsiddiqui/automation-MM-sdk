
# Summary Report

## Structure

`SummaryReport`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Properties` | [`Models.Properties33`](/doc/models/properties-33.md) | Optional | - |
| `Data` | [`List<Models.SummaryReportItem>`](/doc/models/summary-report-item.md) | Optional | - |

## Example (as JSON)

```json
{
  "properties": {
    "end_date": "2017-02-10T13:30:00.000Z",
    "start_date": "2017-02-12T13:30:00.000Z",
    "timezone": "The timezone that this report is presented in, this may be passed in as a parameter to the report, or taken from account settings"
  },
  "data": [
    {}
  ]
}
```

