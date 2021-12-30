
# Delivery Options Body

A delivery option

## Structure

`DeliveryOptionsBody`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DeliveryType` | `string` | Optional | How to deliver the report. |
| `DeliveryAddresses` | `List<string>` | Optional | A list of email addresses to use as the recipient of the email. Only works for EMAIL delivery type |
| `DeliveryFormat` | `string` | Optional | Format of the report. |

## Example (as JSON)

```json
{
  "delivery_type": null,
  "delivery_addresses": null,
  "delivery_format": null
}
```

