
# Recipient

## Structure

`Recipient`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Number` | `string` | Required | The recipient phone number.  Must be E.164 with a leading '+' |
| `Parameters` | `object` | Optional | The recipient scoped template parameters |
| `Scheduled` | `string` | Optional | A message can be scheduled for delivery in the future by setting the scheduled property. The scheduled property expects a date time specified in ISO 8601 format. The scheduled time must be provided in UTC and be no more than 31 days in the future. |

## Example (as JSON)

```json
{
  "number": "number2",
  "parameters": null,
  "scheduled": null
}
```

