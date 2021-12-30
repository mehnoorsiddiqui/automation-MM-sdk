
# Get Async Reports Response

## Structure

`GetAsyncReportsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Data` | [`List<Models.AsyncReport>`](/doc/models/async-report.md) | Optional | List of asynchronous reports |
| `Pagination` | [`Models.Pagination1`](/doc/models/pagination-1.md) | Optional | - |

## Example (as JSON)

```json
{
  "data": [
    {
      "created_datetime": "2017-02-12T13:30:00.000Z",
      "last_modified_datetime": "2017-02-12T13:30:00.000Z"
    }
  ],
  "pagination": {}
}
```

