
# Delivery Report

## Structure

`DeliveryReport`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CallbackUrl` | `string` | Optional | The URL specified as the callback URL in the original submit message request |
| `DateReceived` | `DateTime?` | Optional | The date and time at which this delivery report was generated in UTC. |
| `Delay` | `int?` | Optional | Deprecated, no longer in use |
| `DeliveryReportId` | `Guid?` | Optional | Unique ID for this delivery report |
| `MessageId` | `Guid?` | Optional | Unique ID of the original message |
| `Metadata` | `object` | Optional | Any metadata that was included in the original submit message request |
| `OriginalText` | `string` | Optional | Text of the original message. |
| `SourceNumber` | `string` | Optional | Address from which this delivery report was received<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `Status` | [`Models.StatusEnum?`](/doc/models/status-enum.md) | Optional | The status of the message |
| `SubmittedDate` | `DateTime?` | Optional | The date and time when the message status changed in UTC. For a delivered DR this may indicate the time at which the message was received on the handset. |
| `VendorAccountId` | [`Models.VendorAccountId`](/doc/models/vendor-account-id.md) | Optional | - |

## Example (as JSON)

```json
{
  "callback_url": null,
  "date_received": null,
  "delay": null,
  "delivery_report_id": null,
  "message_id": null,
  "metadata": null,
  "original_text": null,
  "source_number": null,
  "status": null,
  "submitted_date": null,
  "vendor_account_id": null
}
```

