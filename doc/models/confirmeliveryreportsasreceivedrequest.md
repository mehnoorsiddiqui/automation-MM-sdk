
# Confirmeliveryreportsasreceivedrequest

## Structure

`Confirmeliveryreportsasreceivedrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DeliveryReportIds` | `List<Guid>` | Required | Array of unique IDs for the delivery report that this notification represents<br>**Constraints**: *Maximum Items*: `100` |

## Example (as JSON)

```json
{
  "delivery_report_ids": [
    "011dcead-6988-4ad6-a1c7-6b6c68ea628d",
    "3487b3fa-6586-4979-a233-2d1b095c7718",
    "ba28e94b-c83d-4759-98e7-ff9c7edb87a1"
  ]
}
```

