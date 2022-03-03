
# Async Report

## Structure

`AsyncReport`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | Unique ID for this reply |
| `MessageType` | [`Models.MessageTypeEnum?`](../../doc/models/message-type-enum.md) | Optional | - |
| `Type` | [`Models.TypeEnum?`](../../doc/models/type-enum.md) | Optional | - |
| `ReportStatus` | [`Models.ReportStatusEnum?`](../../doc/models/report-status-enum.md) | Optional | - |
| `CreatedDatetime` | `string` | Optional | Date time at which this report was created. |
| `LastModifiedDatetime` | `string` | Optional | Date time at which this report was last modified. |

## Example (as JSON)

```json
{
  "created_datetime": "2017-02-12T13:30:00.000Z",
  "last_modified_datetime": "2017-02-12T13:30:00.000Z"
}
```

